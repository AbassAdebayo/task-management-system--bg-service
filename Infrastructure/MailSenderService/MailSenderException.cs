using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MailSenderService
{
    [Serializable]
    internal class MailSenderException : Exception
    {
        public string message { get; set; }
        public MailSenderException(string? message) : base(message)
        {
        }

        public MailSenderException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
