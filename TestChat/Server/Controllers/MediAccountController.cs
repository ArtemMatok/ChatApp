using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestChat.Server.Data.Entities;
using TestChat.Server.Repositories.AccountRepositoryFolder;
using TestChat.Server.Repositories.MediaAccountRepositoryFold;
using TestChat.Server.Repositories.PostRepositoryFold;
using TestChat.Shared.Data;
using TestChat.Shared.Data.PostFold;

namespace TestChat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediAccountController : ControllerBase
    {
        private readonly IMediaAccountRepository _mediaAccountRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IPostRepository _postRepository;
        public MediAccountController(IMediaAccountRepository mediaAccountRepository, IAccountRepository accountRepository, IPostRepository postRepository)
        {
            _mediaAccountRepository = mediaAccountRepository;
            _accountRepository = accountRepository;
            _postRepository = postRepository;
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<MediaAccount>> GetMediaAccountById(int id)
        {
            var user = await _accountRepository.GetUserById(id);
            if (user is null)
            {
                return BadRequest("User wasn`t found");
            }
            var account = await _mediaAccountRepository.GetMediaAccountByUserName(user.UserName);
            return Ok(account);
        }

        [HttpGet("GetByUserName/{userName}")]
        public async Task<ActionResult<MediaAccount>> GetMediaAccountByUserName(string userName)
        {
            var account = await _mediaAccountRepository.GetMediaAccountByUserName(userName);
            if(account is null)
            {
                return BadRequest("User wasn`t found");
            }
            return Ok(account);
        }

        [HttpPut("UpdateAccount/{userName}")]
        public async Task<IActionResult> UpdateAccount(string userName, MediaAccount updateMediaAccount)
        {
            if(updateMediaAccount is null)
            {
                return BadRequest("UpdateMediaAccount is empty");
            }

            var mediaAccount = await _mediaAccountRepository.GetMediaAccountByUserName(userName);
            if(mediaAccount is null)
            {
                return BadRequest("MediaAccount is empty");
            }

            var user = await _accountRepository.GetUserByUserName(userName);
            if (user is null) 
            {
                return BadRequest("User is empty");
            }
            //Update UserAccount
            user.UserName = updateMediaAccount.UserName;
            user.Name = updateMediaAccount.FullName;
            _accountRepository.Update(user);
            //Update MediaAccount
            mediaAccount.FullName = updateMediaAccount.FullName;
            mediaAccount.UserName = updateMediaAccount.UserName;
            mediaAccount.Photo = updateMediaAccount.Photo;
            mediaAccount.Description = updateMediaAccount.Description;
            _mediaAccountRepository.Update(mediaAccount);
            return Ok("Success");
        }


        [HttpPut("UpdateAccountByPost/{userName}")]
        public async Task<IActionResult> UpdateAccountByPost(string userName, Post post)
        {
            var mediaAccount = await _mediaAccountRepository.GetMediaAccountByUserName(userName);
            if (mediaAccount is null)
            {
                return NotFound();
            }
            if(post is null)
            {
                return BadRequest("Post is null");
            }
            mediaAccount.Posts.Add(post);
            _mediaAccountRepository.Update(mediaAccount);
            return Ok("Update Success");

        }


        [HttpGet("GetMediaAccountByPost/{id}")]
        public async Task<ActionResult<MediaAccount>> GetMediaAccountByPost(int id)
        {
            var post = await _postRepository.GetPostById(id);
            if (post is null)
            {
                return BadRequest("Post is null");
            }

            var result = await _mediaAccountRepository.GetMediaAccountLikeByPost(post);

            return Ok(result);
        }
    }
}
