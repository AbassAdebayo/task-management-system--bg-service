using Application.Abstractions.Messaging;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Tasks.ListTasksBasedOnTheirPriorityOrStatusQuery
{
    public sealed record ListTasksBasedOnTheirPriorityOrStatusRequest(Priority Priority, Status Status) : IQuery<ListTasksBasedOnTheirPriorityOrStatusResponse>
    {
    }
}
