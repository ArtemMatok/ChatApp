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
    }
}
