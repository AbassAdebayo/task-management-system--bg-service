using Domain.Contracts.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            return user;
        }

        public async Task<bool> DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            return true;
        }

        public async Task<bool> ExitsAsync(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user != null) return true;
            return false;
        }

        public async Task<User> GetAsync(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public async Task<User> GetAsync(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public async Task<IList<User>> GetAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            return user;
        }
    }
}
