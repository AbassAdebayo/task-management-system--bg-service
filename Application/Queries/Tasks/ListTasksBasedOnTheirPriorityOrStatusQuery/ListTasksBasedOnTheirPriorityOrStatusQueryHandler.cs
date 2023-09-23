using Application.Abstractions.Messaging;
using Application.Queries.Tasks.ListTasksDueWithin48HoursQuery;
using Domain.Contracts.Repositories;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Tasks.ListTasksBasedOnTheirPriorityOrStatusQuery
{
    public sealed record ListTasksBasedOnTheirPriorityOrStatusQueryHandler : IQueryHandler<ListTasksBasedOnTheirPriorityOrStatusRequest, ListTasksBasedOnTheirPriorityOrStatusResponse>
    {
        private readonly ITaskRepository _taskRepository;

        public ListTasksBasedOnTheirPriorityOrStatusQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Result<ListTasksBasedOnTheirPriorityOrStatusResponse>> Handle(ListTasksBasedOnTheirPriorityOrStatusRequest request, CancellationToken cancellationToken)
        {
            var tasksBasedOnTheirPriorityOrStatus = await _taskRepository.GetTasksBasedOnTheirPriorityOrStatus(request.Priority, request.Status);

            var data = new ListTasksBasedOnTheirPriorityOrStatusResponse(tasksBasedOnTheirPriorityOrStatus);

            return await Result<ListTasksBasedOnTheirPriorityOrStatusResponse>.SuccessAsync(data);
        }
    }

}
