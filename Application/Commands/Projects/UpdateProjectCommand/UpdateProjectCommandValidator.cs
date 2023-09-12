using Application.Commands.Projects.DeleteProjectCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Projects.UpdateProjectCommand
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectRequest>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(x => x.name).NotEmpty();
            RuleFor(x => x.description).NotEmpty();
            RuleFor(x => x.userId).NotEmpty();
            RuleFor(x => x.projectId).NotEmpty();

        }
    }
}
