using TestChat.Server.Data.Entities;
using TestChat.Shared.DTOs;

namespace TestChat.Server.Repositories.AccountRepositoryFolder
{
    public interface IAccountRepository
    {
        Task<User> Register(RegisterDto dto, CancellationToken cancellationToken);    
        Task<User> Login(LoginDto dto, CancellationToken cancellationToken);
        Task<User> GetUserById(int id);
    }
}
