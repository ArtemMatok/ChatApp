using Microsoft.EntityFrameworkCore;
using TestChat.Server.Data;
using TestChat.Shared.Data.PostFold;

namespace TestChat.Server.Repositories.CommentRepositoryFold
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Delete(Comment comment)
        {
            _context.Comments.Remove(comment);
            return Save();
        }

        public async Task<Comment> GetCommentById(int id)
        {
            return await _context.Comments.Include(x=>x.Likes).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Comment>> GetCommentsByPost(int postId)
        {
            return await  _context.Comments.Where(x => x.PostId == postId).Include(x => x.Likes).ToListAsync();

        }

        public bool Save()
        {
           var saved = _context.SaveChanges();
            return saved>0? true : false;
        }

        public async Task<bool> UpdateCommentByAnswerComments(int commentId, Comment answerComment)
        {
            var comment = await GetCommentById(commentId);  

            if (comment == null)
            {
                return false;
            }

            comment.AnswerComments.Add(answerComment);  
            _context.Comments.Update(comment);

            return Save();
        }

        public async Task<bool> UpdateCommentByLikes(int commentId,Comment commentUpdate)
        {
            var comment = await GetCommentById(commentId);
            if(comment is null)
            {
                return false;
            }

            comment.Likes = commentUpdate.Likes;
            _context.Comments.Update(comment);
            return Save();
        }
    }
}
