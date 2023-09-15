using Application.Abstractions.Messaging;
using Application.Commands.Projects.DeleteProjectCommand;
using Domain.Contracts.Repositories;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Projects.RemoveTaskFromProjectCommand
{
    public sealed record RemoveTaskFromProjectCommandHandler : ICommandHandler<RemoveTaskFromProjectRequest>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveTaskFromProjectCommandHandler(IProjectRepository projectRepository, ITaskRepository taskRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RemoveTaskFromProjectRequest request, CancellationToken cancellationToken)
        {
            var checkProject = await _projectRepository.GetAsync(request.projectId);
            if (checkProject.Id != checkProject.Id) 
            {
                return await Result<string>.FailAsync($"The Project you are referencing does not exist");
            }
            var checkTask = await _taskRepository.GetAsync(request.taskId);
            if(checkTask is null) return await Result<string>.FailAsync($"The Task you are referencing does not exist");

            await _projectRepository.RemoveTaskFromProject(request.projectId, request.taskId);
           
            //Save to Database and return result
            await _unitOfWork.SaveChangesAsync();
            return await Result<string>.SuccessAsync($"Task Successfully Removed from Project");
        }
    }
}
