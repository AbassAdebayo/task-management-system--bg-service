using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Tasks.ListTasksBasedOnTheirPriorityOrStatusQuery
{
    public sealed record ListTasksBasedOnTheirPriorityOrStatusResponse(IList<Domain.Entities.Tasks> tasks)
    {
    }
}
