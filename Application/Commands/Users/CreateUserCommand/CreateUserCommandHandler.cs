using Application.Abstractions.Messaging;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.MailServices.MailVerification;
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
        private readonly IMailAddressVerificationService _mailAddressVerificationService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUserRepository userRepository, IMailAddressVerificationService mailAddressVerificationService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mailAddressVerificationService = mailAddressVerificationService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //Check if user exits 
            var _ifUserExists = await _userRepository.ExitsAsync(request.email);
            if (_ifUserExists)
            {
                return await Result<string>.FailAsync($"User with Email {request.email} already exist");
            }

            //Verify email
            var verifyEmail = await _mailAddressVerificationService.VerifyMailAddress(request.email);
            if (!verifyEmail.IsSuccess)
            {
                return await Result<string>.FailAsync($"Email verification failed: this could be that the email doesn't exist");
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
