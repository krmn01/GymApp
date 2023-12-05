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
        public CreateUsersProfileCommandHandler(IUsersProfileRepository profileRepository)
        {
            _userProfileRepository = profileRepository;
        }

        public async Task<Guid> Handle(CreateUsersProfileCommand request, CancellationToken cancellationToken)
        {
            
            var newProfile = new Domain.Entities.UsersProfile
            {
                Id = new Guid(),
                UsersId = request.UserId,
                TrainingGoals = new List<Domain.Entities.TrainingGoal>(),
                Classes = new List<Domain.Entities.Class>(),
                ProfilePictureId = request.ProfilePictureId,
                ProfileDescription = string.Empty,
            };
                        
            await _userProfileRepository.CreateAsync(newProfile);
            return newProfile.Id;
        }
    }
}
