using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Projects.DeleteProjectCommand
{
    public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectRequest>
    {
        public DeleteProjectCommandValidator()
        {
            RuleFor(x => x.projectId).NotEmpty();
            RuleFor(x => x.userId).NotEmpty();
        }
    }
}
