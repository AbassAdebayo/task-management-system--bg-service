using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Tasks.DeleteTaskCommand
{
    public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskRequest>
    {
        public DeleteTaskCommandValidator()
        {
            RuleFor(x => x.userId).NotEmpty();
            RuleFor(x => x.taskId).NotEmpty();
        }
    }
}
