using TestChat.Server.Data;
using TestChat.Server.Data.Entities;

namespace TestChat.Server.Repositories.MediaAccountRepositoryFold
{
    public class MediaAccountRepository : IMediaAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public MediaAccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(MediaAccount mediaAccount)
        {
            if (mediaAccount == null)
            {
                return false;
            }
           _context.MediaAccounts.Add(mediaAccount);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
