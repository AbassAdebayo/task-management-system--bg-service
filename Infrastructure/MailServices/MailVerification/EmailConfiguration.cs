using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MailServices.MailVerification
{
    public class EmailConfiguration
    {
        public string ApiKey { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string TaskDueNotificationSubject { get; set; }
        public string ChangePasswordSubject { get; set; }
        public string ResetPasswordSubject { get; set; }
        public string VerificationSubject { get; set; }
    }
}
