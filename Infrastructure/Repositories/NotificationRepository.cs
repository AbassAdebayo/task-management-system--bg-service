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
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Notification> AddAsync(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
            return notification;
        }

        public async Task<bool> DeleteAsync(Notification notification)
        {
            _context.Notifications.Remove(notification);
            return true;
        }

        public async Task<IList<Notification>> GetAllAsync(Guid userId)
        {
            return await _context.Notifications.Where(u => u.UserId == userId).ToListAsync();
        }

        public async Task<Notification> GetAsync(Guid userId)
        {
            return await _context.Notifications.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<Notification> UpdateAsync(Notification notification)
        {
            _context.Notifications.Update(notification);
            return notification;
        }
    }
}
