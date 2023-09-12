using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Projects.UpdateProjectCommand
{
    public sealed record UpdateProjectRequest(Guid projectId, Guid userId, string name, string description) : ICommand
    {
    }
}
