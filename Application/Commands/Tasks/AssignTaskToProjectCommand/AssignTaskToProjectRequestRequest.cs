using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Tasks.AssignTaskToProjectCommand
{
    public sealed record AssignTaskToProjectRequest(Guid taskId, Guid projectId) : ICommand
    {
    }
}
