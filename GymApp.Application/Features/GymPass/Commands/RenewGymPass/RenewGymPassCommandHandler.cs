using GymApp.Application.Exceptions;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.GymPass.Commands.RenewGymPass
{
    public class RenewGymPassCommandHandler : IRequestHandler<RenewGymPassCommand, Guid>
    {
        private readonly IGymPassRepository _gymPasses;
        private readonly IUsersProfileRepository _usersProfileRepository;
        public RenewGymPassCommandHandler(IGymPassRepository gymPasses, IUsersProfileRepository usersProfileRepository)
        {
            _gymPasses = gymPasses;
            _usersProfileRepository = usersProfileRepository;
        }
        public async Task<Guid> Handle(RenewGymPassCommand request, CancellationToken cancellationToken)
        {
            var user = await _usersProfileRepository.GetByIdAsync(request.ProfileId) ??
                throw new NotFoundException(new Domain.Entities.UsersProfile(), request.ProfileId.ToString());
            var gymPass = await _gymPasses.GetByIdAsync(user.GymPassId);

            if (gymPass.StartedOn == gymPass.ValidTill)
            {
                gymPass.StartedOn = DateTime.Now;
                gymPass.ValidTill = DateTime.Now.AddDays((double)request.NumberOfDays);
                await _gymPasses.UpdateAsync(gymPass);
                return gymPass.Id;
            }

           
            gymPass.ValidTill = ((DateTime)gymPass.ValidTill).AddDays((double)request.NumberOfDays);
            await _gymPasses.UpdateAsync(gymPass);
            return gymPass.Id;
        }
    }
}
