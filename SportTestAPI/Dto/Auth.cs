using System.ComponentModel.DataAnnotations;

namespace SportTestAPI.Dto
{
    public class AuthRegister
    {

        [Required]
        public string? FullName { get; set; }

        //[Required]
        //public string? LastName { get; set; }

        [Required]
        public string? Gender { get; set; }


        [Required]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required ")]
        public string? Password { get; set; }

        public string Username { get; set; }

        public string ProfilePicture { get; set; } = "";
    }

    public  class AuthLogin
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }


    }

    public class RegisterResponse
    {
        public string Message { get; set; }
        public string? Token { get; set; }
        public bool Success { get; set; }
    }

    // Request Model for 2FA Verification
    public class Verify2FARequest
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
    //ForgotPassword request
    public class ForgotPasswordRequest
    {
        public string Email { get; set; }
    }
}
