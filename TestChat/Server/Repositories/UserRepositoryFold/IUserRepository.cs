using TestChat.Shared.DTOs;

namespace TestChat.Server.Repositories.UserRepositoryFold
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetUsers(int userId);
    }
}
