using Domain.Contracts.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extentions
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services

                // Add Services

                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ITaskRepository, TaskRepository>()
                .AddScoped<IProjectRepository, ProjectRepository>()
                .AddScoped<INotificationRepository, NotificationRepository>()

                // Add transaction service || unit of work
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
