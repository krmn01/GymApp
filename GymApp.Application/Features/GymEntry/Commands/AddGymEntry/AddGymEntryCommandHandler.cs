using GymApp.Application.Exceptions;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.GymEntry.Commands.AddGymEntry
{
    public class AddGymEntryCommandHandler : IRequestHandler<AddGymEntryCommand, Guid>
    {
        private readonly IUsersProfileRepository _userProfileRepository;
        private readonly IGymEntryRepository _gymEntryRepository;

        public AddGymEntryCommandHandler(IGymEntryRepository gymEntryRepository,IUsersProfileRepository usersProfileRepository)
        {
            _gymEntryRepository = gymEntryRepository;
            _userProfileRepository = usersProfileRepository;
        }
        public async Task<Guid> Handle(AddGymEntryCommand request, CancellationToken cancellationToken)
        {
            var user = await _userProfileRepository.GetByIdAsync(request.profileId) ??
                throw new NotFoundException(new Domain.Entities.UsersProfile(), request.profileId.ToString());
            var newEntry = new Domain.Entities.GymEntry
            {
                Id = new Guid(),
                EnteredOn = DateTime.Now,
                ExitedOn = DateTime.Now + new TimeSpan(0, request.timeInMinutes, 0),
                GymPassId = user.GymPassId
            };
            await _gymEntryRepository.CreateAsync(newEntry);
            return newEntry.Id;
        }
    }
}
