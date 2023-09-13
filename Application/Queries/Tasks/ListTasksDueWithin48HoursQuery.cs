using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Tasks
{
    public sealed record ListTasksDueWithin48HoursQuery() : IQuery<ListTasksDueWithin48HoursQueryResponse>
    {
    }
}
