using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Notification : BaseEntity
    {
        public Notification() { }

        public Notification(Guid userId, string type, string message, DateTime timeStamp)
        {
            UserId = userId;
            Type = type;
            Message = message;
            TimeStamp = timeStamp;
        }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public string? Type { get; set; }
        public string? Message { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
