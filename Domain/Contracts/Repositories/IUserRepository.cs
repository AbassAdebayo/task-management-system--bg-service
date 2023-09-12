using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<User> GetAsync(string email);
        Task<User> GetAsync(Guid id);
        Task<IList<User>> GetAsync();
        Task<bool> ExitsAsync(string email);
        Task<bool> DeleteAsync(User user);
    }
}
