using Application.Abstractions.Messaging;
using Domain.Contracts.Repositories;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Tasks.DeleteTaskCommand
{
    public class DeleteTaskCommandHandler : ICommandHandler<DeleteTaskRequest>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTaskCommandHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteTaskRequest request, CancellationToken cancellationToken)
        {
            //check if the user id and task id exist
            var task = await _taskRepository.GetTaskAsync(request.taskId);
            if (task.Id != request.taskId && task.UserId != request.userId)
            {
                return await Result<string>.FailAsync($"Error Deleting Task, Check your details");
            }

            //delete task
            await _taskRepository.DeleteAsync(task);

            //Save to Database and return result
            await _unitOfWork.SaveChangesAsync();
            return await Result<string>.SuccessAsync($"Task Successfully Deleted");
        }
    }
}
