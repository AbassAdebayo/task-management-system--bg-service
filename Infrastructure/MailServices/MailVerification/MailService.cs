using Infrastructure.MailSenderService;
using Infrastructure.Messaging.Models;
using Infrastructure.TemplateEngine;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MailServices.MailVerification
{
    public class MailService : IMailService
    {
        private readonly IMailSenderService _mailSender;
        private readonly IRazorEngine _razorEngine;
        private readonly EmailConfiguration _emailConfiguration;
        private readonly ILogger<MailService> _logger;

        public MailService(IMailSenderService mailSender, IRazorEngine razorEngine, EmailConfiguration emailConfiguration, ILogger<MailService> logger)
        {
            _mailSender = mailSender;
            _razorEngine = razorEngine;
            _emailConfiguration = emailConfiguration;
            _logger = logger;
        }

        public async Task<bool> SendNotificationWhenTaskDueWithin48Hours(string email, string name)
        {
            try
            {
                var model = new NotificationWhenTaskDueWithin48HoursViewModel()
                {
                    Name = name,
                    Email = email,
                    
                };
                var mailBody = await _razorEngine.ParseAsync("SendNotificationWhenTaskDueWithin48Hours", model);
                return await _mailSender.Send(_emailConfiguration.FromEmail, _emailConfiguration.FromName, email, name, _emailConfiguration.TaskDueNotificationSubject, mailBody);
            }
            catch(RazorEngineException ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
            catch (MailSenderException ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
