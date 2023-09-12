using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Projects.CreateProjectCommand
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectRequest>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(x => x.name).NotEmpty();
            RuleFor(x => x.description).NotEmpty();
            RuleFor(x => x.userId).NotEmpty();
        }
    }
}
