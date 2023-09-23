using Application.Abstractions.Messaging;
using Application.Queries.Tasks.ListTasksDueWithin48HoursQuery;
using Domain.Contracts.Repositories;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Queries.Tasks.ListUserDueTasksOfTheWeek
{
    public sealed record ListUserDueTasksOfTheWeekQueryHandler : IQueryHandler<ListUserDueTasksOfTheWeekRequest, ListUserDueTasksOfTheWeekQueryResponse>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;

        public ListUserDueTasksOfTheWeekQueryHandler(ITaskRepository taskRepository, IUserRepository userRepository)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
        }

        public async Task<Result<ListUserDueTasksOfTheWeekQueryResponse>> Handle(ListUserDueTasksOfTheWeekRequest request, CancellationToken cancellationToken)
        {
            var checkUser = await _userRepository.GetAsync(request.userId);
            if(checkUser is null)
            {
                return await Result<ListUserDueTasksOfTheWeekQueryResponse>.FailAsync("User does not exist");

            }

            var userDueTasksOfTheWeek = await _taskRepository.FetchUserDueTasksOfTheWeek(checkUser.Id);
            var data = new ListUserDueTasksOfTheWeekQueryResponse(userDueTasksOfTheWeek);

            return await Result<ListUserDueTasksOfTheWeekQueryResponse>.SuccessAsync(data);
        }
    }
    
    
}
