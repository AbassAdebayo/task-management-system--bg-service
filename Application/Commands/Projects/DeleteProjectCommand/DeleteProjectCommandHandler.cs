using Application.Abstractions.Messaging;
using Domain.Contracts.Repositories;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Projects.DeleteProjectCommand
{
    public class DeleteProjectCommandHandler : ICommandHandler<DeleteProjectRequest>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteProjectRequest request, CancellationToken cancellationToken)
        {
            //check if the user id and project id exist
            var project = await _projectRepository.GetAsync(request.projectId);
            if (project.Id != request.projectId && project.UserId != request.userId)
            {
                return await Result<string>.FailAsync($"Error Deleting Project, Check your details");
            }

            //delete task
            await _projectRepository.DeleteAsync(project);

            //Save to Database and return result
            await _unitOfWork.SaveChangesAsync();
            return await Result<string>.SuccessAsync($"Project Successfully Deleted");
        }
    }
}
