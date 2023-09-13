using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MailSenderService
{
    public interface IMailSenderService
    {
        Task<bool> Send(string from, string fromName, string to, string toName, string subject, string message, IDictionary<string, Stream> attachments = null);
    }
}
