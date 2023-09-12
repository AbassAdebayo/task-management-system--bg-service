using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.CreateUserCommand
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator() 
        {
            RuleFor(x => x.name).NotEmpty();
            RuleFor(x => x.email).NotEmpty()
                .EmailAddress()
                .WithMessage("Email must be valid.");
        }
    }
}
