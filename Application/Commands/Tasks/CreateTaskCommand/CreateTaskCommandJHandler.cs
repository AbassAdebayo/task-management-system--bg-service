using Application.Abstractions.Messaging;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Tasks.CreateTaskCommand
{
    public class CreateTaskCommandJHandler : ICommandHandler<CreateTaskRequest>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTaskCommandJHandler(IUnitOfWork unitOfWork, ITaskRepository taskRepository, IUserRepository userRepository)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateTaskRequest request, CancellationToken cancellationToken)
        {
            //check if the user exist
            var user = await _userRepository.GetAsync(request.userId);
            if (user.Id != request.userId)
            {
                return await Result<string>.FailAsync($"User details does not exist");
            }

            //create task
            var task = new Domain.Entities.Tasks(request.tittle, user.Id, request.description, request.dueDate, request.priority, request.status);
            var result = await _taskRepository.AddAsync(task);

            //Save to Database and return result
            await _unitOfWork.SaveChangesAsync();
            return await Result<string>.SuccessAsync($"Task with Tittle: {task.Tittle} was created Successfully");
        }
    }
}
