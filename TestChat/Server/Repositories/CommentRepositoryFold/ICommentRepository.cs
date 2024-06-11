using TestChat.Shared.Data.PostFold;
using TestChat.Shared.Data.PostFold.CommentFold;

namespace TestChat.Server.Repositories.CommentRepositoryFold
{
    public interface ICommentRepository
    {
        Task<Comment> GetCommentById(int id);
        Task<List<Comment>> GetCommentsByPost(int postId);
        
        bool UpdateCommentByAnswerComment(Comment comment, AnswerComment answer);
        
        bool Delete(Comment comment);
        bool Save();
    }
}
