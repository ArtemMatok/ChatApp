using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using TestChat.Server.Repositories.CommentRepositoryFold;
using TestChat.Shared.Data.PostFold;

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

        [HttpPut("UpdateCommentByLike/{commentId}")]
        public async Task<IActionResult> UpdateCommentByLike(int commentId,Comment commentUpdated)
        {
            if(commentUpdated == null)
            {
                return BadRequest("Comment is null");
            }
            var result = await _commentRepository.UpdateCommentByLikes(commentId, commentUpdated);  

            if(result)
            {
                return Ok("Updated!");
            }
            else
            {
                return BadRequest("Something went wrong...");
            }
        }

        [HttpPut("UpdateCommentByAnswerComments/{commentId}")]
        public async Task<IActionResult> UpdateCommentByAnswerComments(int commentId, Comment answerComment)
        {
            var result = await _commentRepository.UpdateCommentByAnswerComments(commentId, answerComment);

            if(result)
            {
                return Ok("Answer Comment Added");
            }
            else
            {
                return BadRequest("Something went wrong...");
            }
        }
    }
}
