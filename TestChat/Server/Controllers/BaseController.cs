﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TestChat.Server.Controllers
{
    [Authorize]
    public abstract class BaseController : ControllerBase
    {
        private int _userId;
        public int UserId
        {
            get
            {
                if (_userId == 0)
                {
                    _userId = Convert.ToInt32(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
                }
                return _userId;
            }

        }

    }
}
