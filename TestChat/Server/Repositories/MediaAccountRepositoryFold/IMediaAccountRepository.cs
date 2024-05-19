using TestChat.Server.Data.Entities;
using TestChat.Shared.Data;

namespace TestChat.Server.Repositories.MediaAccountRepositoryFold
{
    public interface IMediaAccountRepository
    {
        bool Create(MediaAccount mediaAccount);
        bool Save();
        Task<MediaAccount> GetMediaAccountByUserName(string userName);

    }
}
