using Domain.Contracts.Repositories;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tasks> AddAsync(Tasks task)
        {
            await _context.Tasks.AddAsync(task);
            return task;
        }

        public async Task<bool> DeleteAsync(Tasks task)
        {
            _context.Tasks.Remove(task);
            return true;
        }

        public async Task<bool> ExitsAsync(Guid id)
        {
            var task = _context.Tasks.FirstOrDefault(u => u.Id == id);
            if (task != null) return true;
            return false;
        }

        public Task<IList<Tasks>> FetchDueTaskOfTheWeek(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Tasks>> GetAsync(Guid userId, Status status = Status.Pending, Priority priority = Priority.Low)
        {
            return await _context.Tasks.Where(u => u.UserId == userId && (u.Status == status && u.Priority == priority)).ToListAsync();
        }

        public async Task<IList<Tasks>> GetAsync(Guid userId)
        {
            return await _context.Tasks.Where(u => u.UserId == userId).ToListAsync();
        }

        public async Task<Tasks> GetTaskAsync(Guid userId)
        {
            return _context.Tasks.FirstOrDefault(u => u.UserId == userId);
        }

        public async Task<Tasks> UpdateAsync(Tasks task)
        {
            _context.Tasks.Update(task);
            return task;
        }
    }
}
