using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MailServices.MailVerification
{
    public interface IMailService
    {
        public Task<bool> SendNotificationWhenTaskDueWithin48Hours(string email, string name);
    }
}
