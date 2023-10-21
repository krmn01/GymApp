using AutoMapper;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.ApplicationUser.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        //private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //public UpdateUserCommandHandler(IUserRepository userRepository,IMapper mapper)
        //{
        //    _mapper = mapper;
        //    _userRepository = userRepository;
        //}
        //public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        //{
        //    //TODO: validation
        //    var updatedUser = _mapper.Map<Domain.Entities.ApplicationUser>(request);
        //    await _userRepository.UpdateAsync(updatedUser);
        //    return Unit.Value;
        //}
    }
}
