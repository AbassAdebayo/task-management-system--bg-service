using Application.Abstractions.Messaging;
using Domain.Contracts.Repositories;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Tasks.ListTasksDueWithin48HoursQuery
{
    public sealed record ListTasksDueWithin48HoursQueryHandler : IQueryHandler<ListTasksDueWithin48HoursRequest, ListTasksDueWithin48HoursQueryResponse>
    {
        private readonly ITaskRepository _taskRepository;

        public ListTasksDueWithin48HoursQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Result<ListTasksDueWithin48HoursQueryResponse>> Handle(ListTasksDueWithin48HoursRequest request, CancellationToken cancellationToken)
        {
            var tasksDueWithin48Hours = await _taskRepository.GetTasksDueWithin48HoursAsync();

            var data = new ListTasksDueWithin48HoursQueryResponse(tasksDueWithin48Hours);

            return await Result<ListTasksDueWithin48HoursQueryResponse>.SuccessAsync(data);
        }
    }
}
