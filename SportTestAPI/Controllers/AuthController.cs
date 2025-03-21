using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using QRCoder;
using SportTestAPI.Database;
using SportTestAPI.Dto;
using SportTestAPI.IGenericRepo;
using ZXing.QrCode.Internal;

namespace SportTestAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
   
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthLogin login)
        {
            //string result = await _authService.LoginAsync(login);
            //return result.StartsWith("2FA") ? BadRequest(result) : Ok(result);
            var response = await _authService.LoginAsync(login);
            if (response == "2FA is enabled. Please provide the 2FA code.")
            {
                return Ok(new { message = response });
            }
            else if (response == "Invalid Email or Password" || response == "Invalid credentials")
            {
                return Unauthorized(new { message = response });
            }
            else
            {
                return Ok(new { token = response });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthRegister register)
        {
            var result = await _authService.RegiAsync(register);
            return Ok(new { message = result });
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            var result = await _authService.ConfirmEmailAsync(email, token);
            if(result=="Email confirmed successfully")
            {
                return Ok(new { message = result });
            }
            return BadRequest(new { message = result });
        }



        // Enable 2FA (QR Code)
        [HttpPost("enable-2fa")]
   
        public async Task<IActionResult> Enable2FA([FromBody] string email)
        {
            var (success, qrCodeBytes, secretKey, message) = await _authService.Enable2FAAsync(email);

            if (!success)
            {
                return BadRequest(new { message });
            }

            // Return QR code image as PNG
            return File(qrCodeBytes, "image/png");
        }
        // Verify 2FA Code
        [HttpPost("verify-2fa")]
        public async Task<IActionResult> Verify2FA([FromBody] Verify2FARequest request)
        {
            bool isValid = await _authService.VerifyTwoFactorAsync(request.Email, request.Code);
            return isValid ? Ok("2FA enabled successfully") : BadRequest("Invalid OTP code");
        }

        //[HttpGet("protected")]
        //[Authorize(Roles ="Admin")]
        //public IActionResult Protected()
        //{
        //    return OK(new { Message = "This is a protected endpoint for Admins only" });
        //}

        
    }
}

