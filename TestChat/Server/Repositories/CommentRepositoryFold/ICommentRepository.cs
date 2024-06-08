using TestChat.Shared.Data.PostFold;

namespace TestChat.Server.Repositories.CommentRepositoryFold
{
    public interface ICommentRepository
    {
        Task<Comment> GetCommentById(int id);
        Task<List<Comment>> GetCommentsByPost(int postId);
        Task<bool> UpdateCommentByLikes(int commentId,Comment commentUpdate);
        bool Delete(Comment comment);
        bool Save();
    }
}
