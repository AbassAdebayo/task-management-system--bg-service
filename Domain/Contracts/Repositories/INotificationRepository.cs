using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Repositories
{
    public interface INotificationRepository
    {
        Task<Notification> AddAsync(Notification notification);
        Task<Notification> UpdateAsync(Notification notification);
        Task<IList<Notification>> GetAllAsync(Guid userId);
        Task<Notification> GetAsync(Guid userId);
        Task<bool> DeleteAsync(Notification notification);
    }
}
