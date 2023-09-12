using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Projects.CreateProjectCommand
{
    public sealed record CreateProjectRequest(Guid userId, string name, string description) : ICommand
    {
    }
}
