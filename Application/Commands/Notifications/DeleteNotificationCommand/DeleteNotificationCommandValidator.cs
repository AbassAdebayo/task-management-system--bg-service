using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Notifications.DeleteNotificationCommand
{
    public class DeleteNotificationCommandValidator : AbstractValidator<DeleteNotificationRequest>
    {
        public DeleteNotificationCommandValidator()
        {
            RuleFor(x => x.userId).NotEmpty();
            RuleFor(x => x.notificationId).NotEmpty();

        }
    }
}
