using TestChat.Shared.Data.PostFold;
using TestChat.Shared.Data.PostFold.CommentFold;

namespace TestChat.Client.Services.CommentServicesFold
{
    public interface ICommentService
    {
        Task<List<Comment>> GetCommentByPost(int postId);
        Task<bool> DeleteComment(int commentId);
        Task<Comment> GetCommentById(int commentId);
        Task<bool> UpdateCommentByLike(int commentId, Comment updateComment);
        Task<bool> UpdateCommentByAnswerComment(int commentId, AnswerComment answer);
   
    }
}
