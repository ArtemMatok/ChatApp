using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestChat.Server.Data.Entities;
using TestChat.Server.Repositories.AccountRepositoryFolder;
using TestChat.Shared.DTOs;

namespace TestChat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly TokenService _tokenService;

        public AccountController(IAccountRepository accountRepository, TokenService tokenService)
        {
            _accountRepository = accountRepository;
            _tokenService = tokenService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto, CancellationToken cancellationToken)
        {
            var user = await _accountRepository.Register(dto, cancellationToken);
            if(user is null)
            {
                return BadRequest("Username is already exist");
            }

            
            return Ok(GenerateToken(user));
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto, CancellationToken cancellationToken)
        {
            var user = await _accountRepository.Login(dto, cancellationToken);
            if(user is not null)
            {
                return Ok(GenerateToken(user));
            }
            else
            {
                return BadRequest("Username/Password is not correct");
            }
        }

        private AuthResponseDto GenerateToken(User user)
        {
            var token = _tokenService.GenerateJWT(user);
            return new AuthResponseDto(new UserDto(user.Id, user.Name), token);
        }
    }
}
