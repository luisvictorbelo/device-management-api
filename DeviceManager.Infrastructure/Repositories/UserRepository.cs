using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.Domain.Entities;
using DeviceManager.Domain.Interfaces;
using DeviceManager.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace DeviceManager.Infrastructure.Repositories
{
    public class UserRepository(DeviceManagerDbContext context) : IUserRepository
    {
        private readonly DeviceManagerDbContext _context = context;

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> CreateAsync(User user)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            user.Id = Guid.NewGuid();
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}