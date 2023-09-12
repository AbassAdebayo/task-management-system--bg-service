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
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Project> AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            return project;
        }

        public async Task<bool> DeleteAsync(Project project)
        {
            _context.Projects.Remove(project);
            return true;
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            var project = _context.Projects.FirstOrDefault(u => u.Id == id);
            if (project != null) return true;
            return false;
        }

        public async Task<IList<Project>> GetAllAsync(Guid userId)
        {
            return await _context.Projects.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<Project> GetAsync(Guid id)
        {
            return _context.Projects.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Project> UpdateAsync(Project project)
        {
            _context.Projects.Update(project);
            return project;
        }
    }
}
