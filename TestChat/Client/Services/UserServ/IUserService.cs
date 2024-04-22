using TestChat.Client.States;
using TestChat.Shared.DTOs;

namespace TestChat.Client.Services.UserServ
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers(AuthenticationState authState);
    }
}
