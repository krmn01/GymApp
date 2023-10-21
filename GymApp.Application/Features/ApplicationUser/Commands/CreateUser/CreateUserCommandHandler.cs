using AutoMapper;
using GymApp.Application.Exceptions;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.ApplicationUser.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //TODO: finish validation
            var validator = new CreateUserCommandValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any()) throw new BadRequestException("Signing up failed",validationResult);

            var newUser = _mapper.Map<Domain.Entities.ApplicationUser>(request);
            await _userRepository.CreateAsync(newUser);
            return newUser.Id;   
        }
    }
}
