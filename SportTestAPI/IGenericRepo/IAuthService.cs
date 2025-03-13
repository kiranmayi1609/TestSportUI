using System.Threading.Tasks;
using SportTestAPI.Dto;


namespace SportTestAPI.IGenericRepo
{
    public interface IAuthService
    {
        //Task<bool> RegisterAsync(AuthRegister register);


      
        Task<RegisterResponse> RegiAsync(AuthRegister register);
        

        //Task<bool> RegisterAsync(AuthRegister register, string requestUrl);

        Task<string>LoginAsync(AuthLogin login);

        Task<string> ConfirmEmailAsync(string email, string token);
        Task<(bool success, byte[] qrCodeImageBytes, string secretKey,string message)> Enable2FAAsync(string email);
        Task<bool> VerifyTwoFactorAsync(string email, string otpcode);

    }
}
