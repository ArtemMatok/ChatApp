using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestChat.Server.Data.Entities;
using TestChat.Server.Repositories.AccountRepositoryFolder;
using TestChat.Server.Repositories.MediaAccountRepositoryFold;
using TestChat.Shared.Data;

namespace TestChat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediAccountController : ControllerBase
    {
        private readonly IMediaAccountRepository _mediaAccountRepository;
        private readonly IAccountRepository _accountRepository;
        public MediAccountController(IMediaAccountRepository mediaAccountRepository, IAccountRepository accountRepository)
        {
            _mediaAccountRepository = mediaAccountRepository;
            _accountRepository = accountRepository;
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
    }
}
