using Application.Abstractions.Messaging;
using Domain.Contracts.Repositories;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users.GetAllUserQuerry
{
    public class GetAllUserQueryHandler : IQueryHandler<GetAllUserRequest, IList<GetAllUserUserResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<IList<GetAllUserUserResponse>>> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
