using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Notifications.DeleteNotificationCommand
{
    public sealed record DeleteNotificationRequest(Guid userId, Guid notificationId) : ICommand
    {
    }
}
