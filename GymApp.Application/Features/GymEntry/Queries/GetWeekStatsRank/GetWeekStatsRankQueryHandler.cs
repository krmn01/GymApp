using GymApp.Application.Interfaces.Identity;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.GymEntry.Queries.GetWeekStatsRank
{
    public class GetWeekStatsRankQueryHandler : IRequestHandler<GetWeekStatsRankQuery, List<GymEntriesWeeklyStatsDTO>>
    {
        private readonly IUsersProfileRepository _userProfileRepository;
        private readonly IGymEntryRepository _gymEntryRepository;
        private readonly IProfilePictureRepository _profilePictureRepository;
        private readonly IUserService _userService;

        public GetWeekStatsRankQueryHandler(IGymEntryRepository gymEntryRepository,IProfilePictureRepository profilePictureRepository, IUsersProfileRepository usersProfileRepository, IUserService userService)
        {
            _gymEntryRepository = gymEntryRepository;
            _userProfileRepository = usersProfileRepository;
            _userService = userService;
            _profilePictureRepository = profilePictureRepository;
        }
        public async Task<List<GymEntriesWeeklyStatsDTO>> Handle(GetWeekStatsRankQuery request, CancellationToken cancellationToken)
        {
            var profiles = await _userProfileRepository.GetAllAsync();
            List<GymEntriesWeeklyStatsDTO> rank = new();

            foreach (var profile in profiles)
            {
                var entriesCount = await _gymEntryRepository.GetWeekEntriesCount(profile.GymPassId);
                var timeSpent = await _gymEntryRepository.GetTotalWeekTime(profile.GymPassId);
                var currentUser = await _userService.GetUserById(profile.UsersId);
                if (!currentUser.Succeeded) continue;

                rank.Add(new GymEntriesWeeklyStatsDTO
                {
                    userName = currentUser.Data.User.UserName,
                    profileId = profile.Id,
                    profilePicture = (await _profilePictureRepository.GetByIdAsync(profile.ProfilePictureId)).Picture,
                    timeSpent = timeSpent,
                    numberOfEntries = entriesCount
                });
            }
            return rank;
        }
    }
}
