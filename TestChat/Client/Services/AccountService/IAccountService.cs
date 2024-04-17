using TestChat.Shared.DTOs;

namespace TestChat.Client.Services.AccountService
{
    public interface IAccountService
    {
        Task<HttpResponseMessage> Login(LoginDto loginModel);
        Task<bool> Register(RegisterDto registerModel);
    }
}
