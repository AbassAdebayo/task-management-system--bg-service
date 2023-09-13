using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Messaging.Models
{
    public class NotificationWhenTaskDueWithin48HoursViewModel : Base
    {
        public string NotificationType { get; set; }
        public List<Domain.Entities.Tasks> DueTasks { get; set; } = new List<Domain.Entities.Tasks> { };

    }
}
