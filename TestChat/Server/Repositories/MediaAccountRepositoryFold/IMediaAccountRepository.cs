using TestChat.Server.Data.Entities;

namespace TestChat.Server.Repositories.MediaAccountRepositoryFold
{
    public interface IMediaAccountRepository
    {
        bool Create(MediaAccount mediaAccount);
        bool Save();
    }
}
