using Microsoft.EntityFrameworkCore;
using TestChat.Server.Data;
using TestChat.Server.Data.Entities;
using TestChat.Shared.Data;

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

        public async Task<MediaAccount> GetMediaAccountByUserName(string userName)
        {
            return await  _context.MediaAccounts.Include(x=>x.Posts).FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(MediaAccount mediaAccount)
        {
            _context.MediaAccounts.Update(mediaAccount);
            return Save();
        }
    }
}
