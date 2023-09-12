using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.DeleteUserCommand
{
    public sealed record DeleteUserRequest(string email) : ICommand
    {
    }
}
