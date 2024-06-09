using TestChat.Shared.Data.PostFold;

namespace TestChat.Client.Services.CommentServicesFold
{
    public interface ICommentService
    {
        Task<List<Comment>> GetCommentByPost(int postId);
        Task<bool> DeleteComment(int commentId);
        Task<Comment> GetCommentById(int commentId);
        Task<bool> UpdateCommentByLike(int commentId, Comment commentUpdated);
        Task<bool> UpdateCommentByAnswerComments(int commentId, Comment answerComment);
    }
}
