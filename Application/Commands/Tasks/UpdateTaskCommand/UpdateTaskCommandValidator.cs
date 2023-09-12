using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Tasks.UpdateTaskCommand
{
    public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskRequest>
    {
        public UpdateTaskCommandValidator()
        {
            RuleFor(x => x.tittle).NotEmpty();
            RuleFor(x => x.description).NotEmpty();
            RuleFor(x => x.userId).NotEmpty();
            RuleFor(x => x.taskId).NotEmpty();
            RuleFor(x => x.dueDate).NotEmpty();
        }
    }
}
