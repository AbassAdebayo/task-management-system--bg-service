using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Tasks.ListTasksDueWithin48HoursQuery
{
    public sealed record ListTasksDueWithin48HoursRequest() : IQuery<ListTasksDueWithin48HoursQueryResponse>
    {
    }
}
