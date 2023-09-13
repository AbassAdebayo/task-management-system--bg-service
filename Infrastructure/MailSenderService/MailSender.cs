using Cloudmersive.APIClient.NETCore.Validate.Client;
using Infrastructure.MailServices.MailVerification;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MailSenderService
{
    public class MailSender : IMailSenderService
    {
        private readonly EmailConfiguration _emailConfiguration;
        public readonly ILogger<MailSender> _logger;

        public MailSender(IOptions<EmailConfiguration> options, ILogger<MailSender> logger)
        {
            _emailConfiguration = options.Value;
            _logger = logger;
        }

        //With SendInBlue Api

        public async Task<bool> Send(string from, string fromName, string to, string toName, string subject, string message, IDictionary<string, Stream> attachments = null)
        {
            if (!Configuration.Default.ApiKey.ContainsKey("api-key"))
            {
                Configuration.Default.ApiKey.Add("api-key", _emailConfiguration.ApiKey);
            }

            var apiInstance = new TransactionalEmailsApi();
            var sendSmtpEmail = new SendSmtpEmail
            {
                HtmlContent = message,
                Subject = subject,
                Sender = new SendSmtpEmailSender(fromName, from),
                To = new List<SendSmtpEmailTo>() { new SendSmtpEmailTo(to, toName) }
            };

            if (attachments != null)
            {
                foreach (var attachment in attachments)
                {
                    sendSmtpEmail.Attachment.Add(new SendSmtpEmailAttachment(content: ReadFully(attachment.Value), name: attachment.Key));
                }
            }

            try
            {
                await apiInstance.SendTransacEmailAsync(sendSmtpEmail);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("Exception when calling TransactionalEmailsApi.SendTransacEmail: " + e.Message);
                throw new MailSenderException(e.Message, e);
            }

        }
        private static byte[] ReadFully(Stream input)
        {
            using MemoryStream ms = new();
            input.CopyTo(ms);
            return ms.ToArray();
        }

    }
}
