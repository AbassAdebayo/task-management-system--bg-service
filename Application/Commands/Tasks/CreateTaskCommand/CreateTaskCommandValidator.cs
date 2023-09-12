using Application.Commands.Users.CreateUserCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Tasks.CreateTaskCommand
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskRequest>
    {
        public CreateTaskCommandValidator() 
        {
            RuleFor(x => x.tittle).NotEmpty();
            RuleFor(x => x.description).NotEmpty();
            RuleFor(x => x.userId).NotEmpty();
            RuleFor(x => x.dueDate).NotEmpty();
        }
    }
}
