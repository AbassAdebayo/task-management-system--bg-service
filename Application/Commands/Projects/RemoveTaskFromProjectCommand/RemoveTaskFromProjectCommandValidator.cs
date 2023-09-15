using Application.Commands.Projects.DeleteProjectCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Projects.RemoveTaskFromProjectCommand
{
    public class RemoveTaskFromProjectCommandValidator : AbstractValidator<RemoveTaskFromProjectRequest>
    {
        public RemoveTaskFromProjectCommandValidator()
        {
            RuleFor(x => x.projectId).NotEmpty();
            RuleFor(x => x.taskId).NotEmpty();
        }
    }
}
