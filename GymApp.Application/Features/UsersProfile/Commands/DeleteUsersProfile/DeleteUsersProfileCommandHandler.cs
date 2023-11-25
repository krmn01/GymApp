using GymApp.Application.Exceptions;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.UsersProfile.Commands.DeleteUsersProfile
{
    public class DeleteUsersProfileCommandHandler : IRequestHandler<DeleteUsersProfileCommand>
    {
        private readonly IUsersProfileRepository _userProfilesRepository;

        public DeleteUsersProfileCommandHandler(IUsersProfileRepository userProfileRepository)
        {
            _userProfilesRepository = userProfileRepository;
        }
        public async Task<Unit> Handle(DeleteUsersProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userProfilesRepository.GetByIdAsync(request.ProfileId) ??
                throw new NotFoundException(new Domain.Entities.UsersProfile(), request.ProfileId.ToString());
            await _userProfilesRepository.DeleteAsync(user);
            return Unit.Value;
        }
    }
}
