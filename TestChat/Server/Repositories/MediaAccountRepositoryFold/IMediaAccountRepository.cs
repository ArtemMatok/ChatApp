using TestChat.Server.Data.Entities;
using TestChat.Shared.Data;
using TestChat.Shared.Data.Account;
using TestChat.Shared.Data.PostFold;

namespace TestChat.Server.Repositories.MediaAccountRepositoryFold
{
    public interface IMediaAccountRepository
    {
        bool Create(MediaAccount mediaAccount);
        bool Update(MediaAccount mediaAccount);
        bool UpdateMediaAccountByFolowAccount(MediaAccount accountCurrent, MediaAccount accountFollowing);
        
        bool Save();
        Task<MediaAccount> GetMediaAccountByUserName(string userName);
        Task<List<MediaAccount>> GetMediaAccountLikeByPost(Post post);
        Task<List<MediaAccount>> GetAllMediaAccounts();
        Task<List<MediaAccount>> GetAllAccountWithoutCurrent(string userNameCurrent);
        
    }
}
