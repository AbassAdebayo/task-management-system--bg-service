using Application.Abstractions.Messaging;
using Domain.Contracts.Repositories;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Notifications.DeleteNotificationCommand
{
    public class DeleteNotificationCommandHandler : ICommandHandler<DeleteNotificationRequest>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteNotificationCommandHandler(INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
        {
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteNotificationRequest request, CancellationToken cancellationToken)
        {
            //check if the user id and notification id exist
            var notification = await _notificationRepository.GetAsync(request.notificationId);
            if (notification.Id != request.notificationId && notification.UserId != request.userId)
            {
                return await Result<string>.FailAsync($"Error Deleting Notification, Check your details");
            }

            //delete task
            await _notificationRepository.DeleteAsync(notification);

            //Save to Database and return result
            await _unitOfWork.SaveChangesAsync();
            return await Result<string>.SuccessAsync($"Notification Successfully Deleted");
        }
    }
}
