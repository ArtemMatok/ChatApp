using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

        public async Task<IEnumerable<UserDto>> GetUsersChats(int userId)
        {
            IEnumerable<UserDto> chatUsers = new List<UserDto>();   
            var uniqueUsers = await _context.Messages
                .AsNoTracking()
                .Where(x => x.FromId == userId || x.ToId == userId)
                .Select(x => new { From = x.FromId, To = x.ToId })
                .Distinct()
                .ToListAsync();

            var uniqueUserIds = new HashSet<int>();
            uniqueUsers.ForEach(x =>
            {
                if(x.From != userId)
                    uniqueUserIds.Add(x.From);

                if(x.To != userId)
                    uniqueUserIds.Add(x.To);
            });

            if(uniqueUserIds.Count>0)
            {
                chatUsers = await _context.Users
                    .AsNoTracking()
                    .Where(x=>uniqueUserIds.Contains(x.Id))
                    .Select(x=>new UserDto(x.Id, x.Name,false))
                    .ToListAsync();
            }
            return chatUsers;
        }
    }
}
