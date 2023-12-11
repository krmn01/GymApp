using GymApp.Application.Exceptions;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.GymEntry.Queries.GetWeekStats
{
    public class GetWeekStatsQueryHandler : IRequestHandler<GetWeekStatsQuery, GymEntriesWeeklyStatsDTO>
    {
        private readonly IUsersProfileRepository _userProfileRepository;
        private readonly IGymEntryRepository _gymEntryRepository;

        public GetWeekStatsQueryHandler(IGymEntryRepository gymEntryRepository, IUsersProfileRepository usersProfileRepository)
        {
            _gymEntryRepository = gymEntryRepository;
            _userProfileRepository = usersProfileRepository;
        }
        public async Task<GymEntriesWeeklyStatsDTO> Handle(GetWeekStatsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userProfileRepository.GetByIdAsync(request.profileId) ??
                throw new NotFoundException(new Domain.Entities.UsersProfile(), request.profileId.ToString());
            var entriesCount = await _gymEntryRepository.GetWeekEntriesCount(user.GymPassId);
            var timeSpent = await _gymEntryRepository.GetTotalWeekTime(user.GymPassId);
            return new GymEntriesWeeklyStatsDTO
            {
                numberOfEntries = entriesCount,
                timeSpent = timeSpent
            };
        }
    }
}
