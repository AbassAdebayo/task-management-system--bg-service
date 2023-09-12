using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Tasks.DeleteTaskCommand
{
    public sealed record DeleteTaskRequest(Guid userId, Guid taskId): ICommand
    {
    }
}
