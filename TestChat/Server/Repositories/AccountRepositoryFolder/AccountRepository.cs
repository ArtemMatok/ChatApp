﻿using Microsoft.EntityFrameworkCore;
using TestChat.Server.Data;
using TestChat.Server.Data.Entities;
using TestChat.Shared.DTOs;

namespace TestChat.Server.Repositories.AccountRepositoryFolder
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Login(LoginDto dto, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == dto.UserName && x.Password == dto.Password, cancellationToken); 
            
            if(user is null)
            {
                return null;
            }
            return user;

        }

        public async Task<User> Register(RegisterDto dto, CancellationToken cancellationToken)
        {
            var userNameExist = await _context.Users.AsNoTracking()
                .AnyAsync(x => x.UserName == dto.UserName, cancellationToken);
            if(userNameExist)
            {
                return null;
            }
            
            var user = new User()
            { 
                UserName = dto.UserName,
                AddedOn = DateTime.Now,
                Name = dto.Name,
                Password = dto.Password
            };
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return user;

        }
    }
}