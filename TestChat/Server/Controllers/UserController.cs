﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestChat.Client.Components;
using TestChat.Server.Repositories.UserRepositoryFold;
using TestChat.Shared.DTOs;

namespace TestChat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("GetUsers")]
        public async Task<ICollection<UserDto>> GetUsers()
        {
            return await _userRepository.GetUsers(UserId);
        }


        [HttpGet("Chats")]
        public async Task<IEnumerable<UserDto>> GetUserChats()
        {
            return await _userRepository.GetUsersChats(UserId);

        }
    }
}
