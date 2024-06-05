using Microsoft.EntityFrameworkCore;
using TestChat.Server.Data;
using TestChat.Shared.Data.PostFold;

namespace TestChat.Server.Repositories.PostRepositoryFold
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Delete(Post post)
        {
           _context.Posts.Remove(post);
            return Save();
        }

        public async Task<Post> GetPostById(int id)
        {
            return await _context.Posts.Include(x=>x.LikesList).FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Post post)
        {
            _context.Posts.Update(post);
            return Save();
        }

        public async Task<bool> UpdatePostByComment(Post postUpdated)
        {
            var post = await GetPostById(postUpdated.Id);
            if (post == null)
            {
                return false;
            }

            post.Comments = postUpdated.Comments;
            _context.Posts.Update(post);
            return Save();
        }

        public async Task<bool> UpdatePostByLike(Post postUpdated)
        {
            var post = await GetPostById(postUpdated.Id);
            if(post == null)
            {
                return false;
            }

            post.LikesList = postUpdated.LikesList;
            _context.Posts.Update(post);
            return Save();
        }
    }
}
