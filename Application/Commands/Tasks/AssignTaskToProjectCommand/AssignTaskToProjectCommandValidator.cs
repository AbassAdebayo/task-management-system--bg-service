using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Tasks.AssignTaskToProjectCommand
{
    public class AssignTaskToProjectCommandValidator : AbstractValidator<AssignTaskToProjectRequest>
    {
        public AssignTaskToProjectCommandValidator()
        {
            RuleFor(t => t.taskId).NotEmpty();
            RuleFor(t => t.projectId).NotEmpty();
      
        }
    }
}
