using TestChat.Shared.Data.PostFold;

namespace TestChat.Server.Repositories.PostRepositoryFold
{
    public interface IPostRepository
    {
        Task<Post> GetPostById(int id);
        Task<bool> UpdatePostByLike(Post postUpdated);
        Task<bool> UpdatePostByComment(Post postUpdated);
        bool Save();
        bool Delete(Post post);
        bool Update(Post post);
    }
}
