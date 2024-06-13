using Microsoft.EntityFrameworkCore;
using TestChat.Server.Data;
using TestChat.Server.Data.Entities;
using TestChat.Shared.Data;
using TestChat.Shared.Data.Account;
using TestChat.Shared.Data.PostFold;

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

        public async Task<List<MediaAccount>> GetAllAccountWithoutCurrent(string userNameCurrent)
        {
            return await _context.MediaAccounts
                .Where(x => x.UserName != userNameCurrent)
            
                .Include(x => x.Following)
                .ToListAsync();
        }

        public async Task<List<MediaAccount>> GetAllMediaAccounts()
        {
            return await _context.MediaAccounts.ToListAsync();
        }

       

        public async Task<MediaAccount> GetMediaAccountByUserName(string userName)
        {
            return await  _context.MediaAccounts
                .Include(x=>x.Posts)
                .Include(x=>x.Following)
                .Include(x=>x.Followers)
                .FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<List<MediaAccount>> GetMediaAccountLikeByPost(Post post)
        {
            var mediaAccountList = new List<MediaAccount>();

            if(post.LikesList == null || post.LikesList.Count== 0)
            {
                return mediaAccountList;
            }

            foreach (var item in post.LikesList)
            {
                var mediaAccount = await GetMediaAccountByUserName(item.UserNameAccount);
                mediaAccountList.Add(mediaAccount); 
            }
            return mediaAccountList;    
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

        public bool UpdateMediaAccountByFolowAccount(MediaAccount accountCurrent, MediaAccount accountFollowing)
        {
            var current = new FolowAccount()
            {
                UserName = accountCurrent.UserName,
                Photo = accountCurrent.Photo
            };

            var following = new FolowAccount()
            {
                UserName = accountFollowing.UserName,
                Photo = accountFollowing.Photo
            };

            accountCurrent.Following.Add(following);
            accountFollowing.Followers.Add(current);

            _context.MediaAccounts.Update(accountCurrent);
            _context.MediaAccounts.Update(accountFollowing);

            return Save();

        }
    }
}
