using TestChat.Shared.Data.PostFold;

namespace TestChat.Server.Repositories.PostRepositoryFold
{
    public interface IPostRepository
    {
        Task<Post> GetPostById(int id);
        bool Save();
        Task<bool> UpdatePostByLike(Post post);
       
    }
}
