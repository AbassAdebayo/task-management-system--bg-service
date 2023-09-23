using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Projects.ListProjectTasksQuery
{
    public sealed record ListProjectTasksQueryResponse(IList<ProjectTasks> projectTasks)
    {
    }
}
