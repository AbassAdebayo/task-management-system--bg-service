using Application.Abstractions.Messaging;
using Application.Queries.Tasks.ListTasksBasedOnTheirPriorityOrStatusQuery;
using Domain.Contracts.Repositories;
using Domain.Wrapper;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Projects.ListProjectTasksQuery
{
    public sealed record ListProjectTasksQueryHandler : IQueryHandler<ListProjectTasksRequest, ListProjectTasksQueryResponse>
    {
        private readonly IProjectRepository _projectRepository;

        public ListProjectTasksQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Result<ListProjectTasksQueryResponse>> Handle(ListProjectTasksRequest request, CancellationToken cancellationToken)
        {
            var projectTasks = await _projectRepository.GetAllProjectTasks();

            var data = new ListProjectTasksQueryResponse(projectTasks);

            return await Result<ListProjectTasksQueryResponse>.SuccessAsync(data);
        }
    }
}
