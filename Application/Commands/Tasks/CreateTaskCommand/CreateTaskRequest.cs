using Application.Abstractions.Messaging;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Tasks.CreateTaskCommand
{
    public sealed record CreateTaskRequest(string tittle, Guid userId, string description, DateTime dueDate, Priority priority, Status status) : ICommand
    {
    }
}
