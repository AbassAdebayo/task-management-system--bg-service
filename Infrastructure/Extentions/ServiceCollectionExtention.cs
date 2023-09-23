using Domain.Contracts.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.MailSenderService;
using Infrastructure.MailServices.MailVerification;
using Infrastructure.Repositories;
using Infrastructure.TemplateEngine;
using MassTransit;
using MassTransit.Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

                // Add mail sender and mail service
                //.AddScoped<IMailAddressVerificationService, MailAddressVerificationService>()
                .AddScoped<IMailService, MailService>()
                .AddScoped<IMailSenderService, MailSender>()
                .AddScoped<IRazorEngine, RazorEngine>()

                // Add transaction service || unit of work
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }
       
    }
}
