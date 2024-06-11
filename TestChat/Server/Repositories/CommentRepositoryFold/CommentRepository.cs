using Microsoft.EntityFrameworkCore;
using TestChat.Server.Data;
using TestChat.Shared.Data.PostFold;
using TestChat.Shared.Data.PostFold.CommentFold;

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
            return await _context.Comments.Include(x=>x.Likes).Include(x=>x.AnswerComments).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Comment>> GetCommentsByPost(int postId)
        {
            var allComments =  await  _context.Comments.Where(x => x.PostId == postId).Include(x => x.Likes).Include(x=>x.AnswerComments).ToListAsync();

            return allComments;
        }

        public bool Save()
        {
           var saved = _context.SaveChanges();
            return saved>0? true : false;
        }

        public bool UpdateCommentByAnswerComment(Comment comment, AnswerComment answer)
        {
            comment.AnswerComments.Add(answer);
            _context.Comments.Update(comment);
            return Save();
        }

       

       

       
    }
}
