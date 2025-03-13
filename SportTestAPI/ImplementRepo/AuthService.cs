
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using QRCoder;
using SportTestAPI.DataModels;
using SportTestAPI.Dto;
using SportTestAPI.IGenericRepo;
using ZXing.QrCode.Internal;
using QRCoder;
using System.Drawing;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Drawing.Imaging;
using SkiaSharp;

namespace SportTestAPI.ImplementRepo
{
    /// <summary>
    /// This service class repsosible for user authentication (registration and login)
    /// it managing user authentication and authorization 
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;//Manages user creation ,deletion user related operations 
        private readonly SignInManager<ApplicationUser> _signInManager;//Handles user sign-in functionalities 
        private readonly IConfiguration _config;
        private readonly IEmailService _emailService;
        

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration config,IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _emailService = emailService;
        }

        public async Task<RegisterResponse> RegiAsync(AuthRegister register)
        {
            if (await _userManager.FindByEmailAsync(register.Email) != null)
            {
                return new RegisterResponse
                {
                    Success = false,
                    Message = "Email is already in use",
                    Token = null
                };
            }
            var user = new ApplicationUser
            {
                 
                FullName = register.FullName,
                Email = register.Email,
                UserName = register.Username ?? register.Email,
                Gender = register.Gender,
                Contact = register.Contact,
                EmailConfirmed = true,
                ProfilePicture=string.IsNullOrEmpty(register.ProfilePicture)? "":register.ProfilePicture
            };

            var result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
            {
                return new RegisterResponse
                {
                    Success = false,
                    Message = string.Join(",", result.Errors.Select(e => e.Description)),
                    Token = null
                };
            }

            // Generate email confirmation token 
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = $"{_config["AppSettings:BaseUrl"]}/confirm_email?token={token}&email={user.Email}";

            await _emailService.SendEmailAsync(user.Email, "Confirm Your Email", confirmationLink);

            return new RegisterResponse
            {
                Success = true,
                Message = "Registration Successful! Please check your email to confirm.",
                Token = token // Now Swagger will display this token
            };

        }

        public async Task<string> ConfirmEmailAsync(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return "Invalid Email";

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded) return "Invalid token or email already confirmed ";
            //nOTIFY THE ADMIN when a user confirms their email 
            string adminEmail = _config["SmtpSettings:FromEmail"];
            string subject = "User Email Verified";
            string message = $"User {user.Email} has successfully verified their email ";
            await _emailService.SendEmailAsync(adminEmail, subject, message);
            return "Email confirmed successfully";
        }


        public async Task <string>LoginAsync(AuthLogin login)
        {
      

            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                return "Invalid Email or Password"; // user not found 
            }

            if (!user.EmailConfirmed)
            {
                return "Please confirm your email before logging in.";
            }

            var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
            if (!result.Succeeded)
            {
                return "Invalid credentials";
            }

            // Check if the user has 2FA enabled
            if (user.TwoFactorEnabled)
            {
                // If 2FA is enabled, return a message requesting the 2FA code
                return "2FA is enabled. Please enter your OTP.";
            }

            // If 2FA is not enabled, generate a JWT token
            var token = GenerateJwtToken(user);
            return token;

        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:ValidIssuer"],
                audience: _config["JwtSettings:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        private byte[] GenerateQRCodeAsBytes(string text)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.L))
                {
                    // Generate QR Code as PNG byte array
                    PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
                    return qrCode.GetGraphic(20); // Returns byte[]
                }
            }



        }

        //Enable 2fa and generate QR code 
        public async Task<(bool success, byte[] qrCodeImageBytes, string secretKey, string message)> Enable2FAAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return (false, null, null, "user not found ");
            //Generate or reset the user's 2FA key 
            var key = await _userManager.GetAuthenticatorKeyAsync(user);
            if(string.IsNullOrEmpty(key))
            {
                await _userManager.GetAuthenticatorKeyAsync(user);
                key = await _userManager.GetAuthenticatorKeyAsync(user);

            }
            // Generate the Google Authenticator-compatible URI
            string authenticatorUri = $"otpauth://totp/MyApp:{user.Email}?secret={key}&issuer=MyApp";

            // Generate QR Code
            //byte[] qrCodeImage = GenerateQRCodeAsBytes(authenticatorUri);

            //return (true, qrCodeImage, key, "Scan the QR code with Google Authenticator and enter the OTP to verify.");

            // Generate QR Code as byte array
            byte[] qrCodeImage = GenerateQRCodeAsBytes(authenticatorUri);

            // Resize the QR code to desired dimensions (e.g., 150x150)
            byte[] resizedQrCodeImage = ResizeImage(qrCodeImage, 150, 150);  // Adjust the size as needed

            return (true, resizedQrCodeImage, key, "Scan the QR code with Google Authenticator and enter the OTP to verify.");
        }

        public async Task<bool> VerifyTwoFactorAsync(string email, string code)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return false;
            }

            // Verify the 2FA Code
           var  isValid = await _userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultAuthenticatorProvider, code);
            if (isValid)
            {
                user.TwoFactorEnabled = true; //Enable 2fA
                await _userManager.UpdateAsync(user);
            }

            // Generate JWT Token on success
            return isValid;
        }



        private byte[] ResizeImage(byte[] originalImageBytes, int width, int height)
        {
            using (var ms = new MemoryStream(originalImageBytes))
            {
                // Load the image from the byte array
                using (var originalBitmap = new Bitmap(ms))
                {
                    // Create a new bitmap with the desired size (width and height)
                    using (var resizedBitmap = new Bitmap(originalBitmap, new Size(width, height)))
                    {
                        // Save the resized image into a memory stream
                        using (var resizedMs = new MemoryStream())
                        {
                            resizedBitmap.Save(resizedMs, ImageFormat.Png); // Save as PNG
                            return resizedMs.ToArray(); // Return resized image as byte array
                        }
                    }
                }
            }
        }
    }
}
