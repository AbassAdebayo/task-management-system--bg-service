using Application.Abstractions.Messaging;
using Application.Commands.Tasks.CreateTaskCommand;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Tasks.AssignTaskToProjectCommand
{
    public class AssignTaskToProjectCommandHandler : ICommandHandler<AssignTaskToProjectRequest>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AssignTaskToProjectCommandHandler(ITaskRepository taskRepository, IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AssignTaskToProjectRequest request, CancellationToken cancellationToken)
        {
            // check if the task exist
            var task = await _taskRepository.GetAsync(request.taskId);
            if(task is null) return await Result<string>.FailAsync($"task with ID {request.taskId} does not exist");

            // check if project exist
            var project = await _projectRepository.GetAsync(request.projectId);
            if (project is null) return await Result<string>.FailAsync($"project with ID {request.projectId} does not exist");

            //Assign task to Project
            await _taskRepository.AssignTaskToProject(request.taskId, request.projectId);

            //save to Database
            await _unitOfWork.SaveChangesAsync();
            return await Result<string>.SuccessAsync($"Task assigned  Successfully");

        }
    }
}
