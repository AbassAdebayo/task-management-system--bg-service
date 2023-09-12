using Application.Abstractions.Messaging;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Projects.CreateProjectCommand
{
    public class CreateProjectCommandHandler : ICommandHandler<CreateProjectRequest>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProjectCommandHandler(IProjectRepository projectRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateProjectRequest request, CancellationToken cancellationToken)
        {
            //check if the user exist
            var user = await _userRepository.GetAsync(request.userId);
            if (user.Id != request.userId)
            {
                return await Result<string>.FailAsync($"User details does not exist");
            }

            //create task
            var project = new Project(user.Id, request.name, request.description);
            var result = await _projectRepository.AddAsync(project);

            //Save to Database and return result
            await _unitOfWork.SaveChangesAsync();
            return await Result<string>.SuccessAsync($"Project with Name: {project.Name} was created Successfully");
        }
    }
}
