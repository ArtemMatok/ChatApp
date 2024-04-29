using TestChat.Shared.DTOs;

namespace TestChat.Server.Repositories.UserRepositoryFold
{
    public interface IUserRepository
    {
        Task<ICollection<UserDto>> GetUsers(int userId);
        Task<IEnumerable<UserDto>> GetUsersChats(int userId);
    }
}
