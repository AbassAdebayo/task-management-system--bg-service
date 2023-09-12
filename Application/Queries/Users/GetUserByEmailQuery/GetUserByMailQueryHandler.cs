using Application.Abstractions.Messaging;
using Domain.Contracts.Repositories;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users.GetUserByEmailQuery
{
    public class GetUserByMailQueryHandler : IQueryHandler<GetUserByMailRequest, GetUserByMailResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByMailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<GetUserByMailResponse>> Handle(GetUserByMailRequest request, CancellationToken cancellationToken)
        {
            //check if user exist
            var _exist = await _userRepository.ExitsAsync(request.email);
            if (!_exist)
            {
                return await Result<GetUserByMailResponse>.FailAsync($"User with Email {request.email} does not exist");
            }

            //fetch user
            var user = await _userRepository.GetAsync(request.email);
            var data = new GetUserByMailResponse(user.Name, user.Email);
            //return result
            return await Result<GetUserByMailResponse>.SuccessAsync(data);
        }
    }
}
