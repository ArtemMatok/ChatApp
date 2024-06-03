using TestChat.Server.Data.Entities;
using TestChat.Shared.Data;
using TestChat.Shared.Data.PostFold;

namespace TestChat.Server.Repositories.MediaAccountRepositoryFold
{
    public interface IMediaAccountRepository
    {
        bool Create(MediaAccount mediaAccount);
        bool Update(MediaAccount mediaAccount);
        bool Save();
        Task<MediaAccount> GetMediaAccountByUserName(string userName);
        Task<List<MediaAccount>> GetMediaAccountLikeByPost(Post post);
    }
}
