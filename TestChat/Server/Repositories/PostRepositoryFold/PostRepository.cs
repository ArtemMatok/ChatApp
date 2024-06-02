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

        public async Task<Post> GetPostById(int id)
        {
            return await _context.Posts.Include(x=>x.LikesList).FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdatePostByLike(Post postUpdated)
        {
            var post = await GetPostById(postUpdated.Id);
            post.Likes = postUpdated.Likes;
            post.LikesList = postUpdated.LikesList;
            _context.Posts.Update(post);
            return Save();
        }
    }
}
