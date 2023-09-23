using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Tasks.ListTasksDueWithin48HoursQuery
{
    public sealed record ListTasksDueWithin48HoursQueryResponse(IList<Domain.Entities.Tasks> tasks)
    { }
    
}
