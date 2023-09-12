using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Projects.DeleteProjectCommand
{
    public sealed record DeleteProjectRequest(Guid userId, Guid projectId) : ICommand
    {
    }
}
