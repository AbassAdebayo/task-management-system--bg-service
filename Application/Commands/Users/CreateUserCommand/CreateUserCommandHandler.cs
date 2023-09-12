using Application.Abstractions.Messaging;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.CreateUserCommand
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUnitOfWork unit, IUserRepository userRepository)
        {
            _unitOfWork = unit;
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //Check if user exits 
            var _ifUserExists = await _userRepository.ExitsAsync(request.email);
            if (_ifUserExists)
            {
                return await Result<string>.FailAsync($"User with Email {request.email} already exist");
            }

            //Create User 
            var user = new User(Guid.NewGuid(), request.name, request.email);
            await _userRepository.AddAsync(user);

            //Save to Database and return result
            await _unitOfWork.SaveChangesAsync();
            return await Result<string>.SuccessAsync($"User with Email: {user.Email} was created Successfully");
        }
    }
}
