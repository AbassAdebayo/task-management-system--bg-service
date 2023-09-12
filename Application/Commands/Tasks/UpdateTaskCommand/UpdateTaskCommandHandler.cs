using Application.Abstractions.Messaging;
using Domain.Contracts.Repositories;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Tasks.UpdateTaskCommand
{
    public class UpdateTaskCommandHandler : ICommandHandler<UpdateTaskRequest>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTaskCommandHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateTaskRequest request, CancellationToken cancellationToken)
        {
            //check if the user id and task id exist
            var task = await _taskRepository.GetTaskAsync(request.taskId);
            if (task.Id != request.taskId && task.UserId != request.userId)
            {
                return await Result<string>.FailAsync($"Error Updating Task, Check your details");
            }

            //update details
            task.Tittle = request.tittle;
            task.Description = request.description;
            task.DueDate = request.dueDate;
            task.Priority = request.priority;
            task.Status = request.status;

            await _taskRepository.UpdateAsync(task);

            //Save to Database and return result
            await _unitOfWork.SaveChangesAsync();
            return await Result<string>.SuccessAsync($"Task Successfully Updated");
        }
    }
}
