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
        private readonly IMapper _mapper;
        public CreateUsersProfileCommandHandler(IUsersProfileRepository profileRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userProfileRepository = profileRepository;
        }

        public async Task<Guid> Handle(CreateUsersProfileCommand request, CancellationToken cancellationToken)
        {
            var newProfile = new Domain.Entities.UsersProfile
            {
                Id = new Guid(),
                UsersId = request.UserId,
                TrainingGoals = new List<TrainingGoal>(),
                Classes = new List<Class>(),
                ProfilePictureId = request.ProfilePictureId,
                ProfileDescription = string.Empty
            };
            await _userProfileRepository.CreateAsync(newProfile);
            return newProfile.Id;
        }
    }
}
