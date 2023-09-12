using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.CreateUserCommand
{
    public sealed record CreateUserCommand(string name, string email) : ICommand
    {
    }
}
