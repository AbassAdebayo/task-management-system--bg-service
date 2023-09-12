using Application.Abstractions.Messaging;
using Domain.Contracts.Repositories;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Projects.UpdateProjectCommand
{
    public class UpdateProjectCommandHandler : ICommandHandler<UpdateProjectRequest>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateProjectRequest request, CancellationToken cancellationToken)
        {
            //check if the user id exist
            var project = await _projectRepository.GetAsync(request.projectId);
            if (project.Id != request.projectId && project.UserId != request.userId)
            {
                return await Result<string>.FailAsync($"Error updating Project, Check your details");
            }

            //update data (mapping)
            project.Name = request.name;
            project.Description = request.description;

            await _projectRepository.UpdateAsync(project);

            //Save to Database and return result
            await _unitOfWork.SaveChangesAsync();
            return await Result<string>.SuccessAsync($"Project Successfully Updated");
        }
    }
}
