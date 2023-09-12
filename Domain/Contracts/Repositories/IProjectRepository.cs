using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Repositories
{
    public interface IProjectRepository
    {
        Task<Project> AddAsync(Project project);
        Task<Project> UpdateAsync(Project project);
        Task<Project> GetAsync(Guid id);
        Task<IList<Project>> GetAllAsync(Guid userId);
        Task<bool> ExistAsync(Guid id);
        Task<bool> DeleteAsync(Project project);
    }
}
