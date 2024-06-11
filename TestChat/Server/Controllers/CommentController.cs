using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using TestChat.Server.Repositories.CommentRepositoryFold;
using TestChat.Shared.Data.PostFold;
using TestChat.Shared.Data.PostFold.CommentFold;

namespace TestChat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet("GetCommentsByPost/{postId}")]
        public async Task<List<Comment>> GetCommentsByPost(int postId)
        {
            var comments = await _commentRepository.GetCommentsByPost(postId);

            if (comments == null) { return new List<Comment>(); }

            return comments;    
        }

        [HttpDelete("DeleteComment/{commentId}")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            var comment = await _commentRepository.GetCommentById(commentId);
            
            if(comment == null)
            {
                return NotFound();  
            }

            var result = _commentRepository.Delete(comment);

            if(result)
            {
                return Ok("Deleted!");
            }
            else
            {
                return BadRequest("Something went wrong...");
            }
        }

        [HttpGet("GetCommentById/{commentId}")]
        public async Task<ActionResult<Comment>> GetCommentById(int commentId)
        {
            var result = await _commentRepository.GetCommentById(commentId);
            
            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);  
        }

        


        [HttpPut("UpdateCommentByAnswerComment/{commentId}")]
        public async Task<IActionResult> UpdateCommentByAnswerComment(int commentId, AnswerComment answer)
        {
            if(answer == null)
            {
                return BadRequest("Answer is null");
            }

            var comment = await _commentRepository.GetCommentById(commentId);

            if(comment is null)
            {
                return NotFound();
            }

            var result = _commentRepository.UpdateCommentByAnswerComment(comment, answer);

            if(result)
            {
                return Ok("AnswerComment Added");
            }
            else { return BadRequest("Something went wrong..."); }
        }



        [HttpPut("UpdateCommentByLike/{commentId}")]
        public async Task<IActionResult> UpdateCommentByLike(int commentId, Comment updateComment)
        {
            var comment = await _commentRepository.GetCommentById(commentId);
            if(comment is null)
            {
                return NotFound();
            }

            if(updateComment is null)
            {
                return BadRequest("Updated Comment is null");
            }

            var result = _commentRepository.UpdateCommentByLiked(comment, updateComment);
            if(result)
            {
                return Ok("Like was added");
            }
            else
            {
                return BadRequest("Something went wrong...");
            }

        }
    }
}
