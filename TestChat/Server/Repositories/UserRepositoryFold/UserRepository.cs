using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TestChat.Server.Data;
using TestChat.Shared.DTOs;

namespace TestChat.Server.Repositories.UserRepositoryFold
{
    
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<UserDto>> GetUsers(int userId)
        {
            return await _context.Users.AsNoTracking()
                .Where(x=>x.Id != userId)
                .Select(x => new UserDto(x.Id, x.Name,false))
                .ToListAsync();
        }
    }
}
