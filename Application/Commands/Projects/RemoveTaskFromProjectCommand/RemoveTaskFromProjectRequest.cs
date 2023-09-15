using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Projects.RemoveTaskFromProjectCommand
{
    public sealed record class RemoveTaskFromProjectRequest(Guid projectId, Guid taskId) : ICommand
    {
    }
}
