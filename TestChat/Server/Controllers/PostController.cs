using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestChat.Server.Repositories.PostRepositoryFold;
using TestChat.Shared.Data.PostFold;

namespace TestChat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet("GetPostById/{id}")]
        public async Task<ActionResult<Post>> GetPostById(int id)
        {
            var post = await _postRepository.GetPostById(id);

            if(post == null)
            {
                return BadRequest("Post wasn`t found");
            }
            return Ok(post);    
        }

        [HttpPut("UpdatePostByLike")]
        public async Task<IActionResult> UpdatePostByLike(Post post)
        {
            if(post == null)
            {
                return BadRequest("Post is null");    
            }

            var result = await _postRepository.UpdatePostByLike(post);



            if(result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }


        [HttpDelete("DeletePost/{postId}")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            var post = await _postRepository.GetPostById(postId);
            if(post == null)
            {
                return BadRequest("Post wasn`t found");
            }
            if(_postRepository.Delete(post))
            {
                return Ok("Post was deleted");
            }
            return BadRequest("Something going wrong");
        }

        [HttpPut("Update/{postId}")]
        public async Task<IActionResult> UpdatePost(int postId, Post postUpdated)
        {
            var post = await _postRepository.GetPostById(postId);
            if(post == null)
            {
                return BadRequest("Post wasn`t found");
            }
            post.Title = postUpdated.Title;
            post.Access = postUpdated.Access;
            
            if(_postRepository.Update(post))
            {
                return Ok("Update Success");
            }
            else
            {
                return BadRequest("Something went wrong");
            }

        }


        [HttpPut("UpdatePostByPost")]
        public async Task<IActionResult> UpdatePostByPost(Post post)
        {
            if (post == null)
            {
                return BadRequest("Post is null");
            }

            var result = await _postRepository.UpdatePostByLike(post);



            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
