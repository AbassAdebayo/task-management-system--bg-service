using Application.Abstractions.Messaging;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Tasks.UpdateTaskCommand
{
    public sealed record UpdateTaskRequest(Guid taskId,string tittle, Guid userId, string description, DateTime dueDate, Priority priority, Status status) : ICommand
    {
    }
}
