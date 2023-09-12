using Application.Abstractions.Messaging;
using Domain.Contracts.Repositories;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.UpdateUserCommand
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            //Check if user exits 
            var _UserExists = await _userRepository.ExitsAsync(request.email);
            if (!_UserExists)
            {
                return await Result<string>.FailAsync($"User with Email {request.email} does not exist");
            }

            //fetch user
            var user = await _userRepository.GetAsync(request.email);

            //update data
            user.Name = request.name;
            user.Email = request.email;

            //send command
            await _userRepository.UpdateAsync(user);

            //fullfill transaction
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            //return result
            return await Result<string>.SuccessAsync($"User with Email: {user.Email} was Successfully updated");

        }
    }
}
