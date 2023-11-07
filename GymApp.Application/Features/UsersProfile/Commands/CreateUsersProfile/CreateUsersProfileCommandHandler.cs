using AutoMapper;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.UsersProfile.Commands.CreateUsersProfile
{
    public class CreateUsersProfileCommandHandler : IRequestHandler<CreateUsersProfileCommand,Guid>
    {
        private readonly IUsersProfileRepository _userProfileRepository;
        private readonly IGymPassRepository _gymPassRepository;
        private readonly IMapper _mapper;
        public CreateUsersProfileCommandHandler(IUsersProfileRepository profileRepository, IMapper mapper, IGymPassRepository gymPassRepository)
        {
            _mapper = mapper;
            _userProfileRepository = profileRepository;
            _gymPassRepository = gymPassRepository;
        }

        public async Task<Guid> Handle(CreateUsersProfileCommand request, CancellationToken cancellationToken)
        {
            var gymPass = new Domain.Entities.GymPass
            {
                Id = Guid.NewGuid(),
                ValidTill = DateTime.Now,
                StartedOn = DateTime.Now,
            };

            var newProfile = new Domain.Entities.UsersProfile
            {
                Id = new Guid(),
                UsersId = request.UserId,
                TrainingGoals = new List<Domain.Entities.TrainingGoal>(),
                Classes = new List<Domain.Entities.Class>(),
                ProfilePictureId = request.ProfilePictureId,
                ProfileDescription = string.Empty,
                GymPassId =  gymPass.Id
            };
            
            gymPass.ProfileId = newProfile.Id;

            await _gymPassRepository.CreateAsync(gymPass);
            await _userProfileRepository.CreateAsync(newProfile);
            return newProfile.Id;
        }
    }
}
