using GymApp.Application.Exceptions;
using GymApp.Application.Features.GymEntry;
using GymApp.Application.Features.GymEntry.Queries.GetWeekStats;
using GymApp.Application.Interfaces.Persistence;
using GymApp.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GymApp.UnitTests.Features.GymEntry.Queries.GetWeekStats
{
    public class GetWeekStatsQueryHandlerTests
    {
        private readonly Mock<IGymEntryRepository> _entriesMock;
        private readonly Mock<IUsersProfileRepository> _usersMock;

        public GetWeekStatsQueryHandlerTests()
        {
            _entriesMock = MockGymEntryRepository.GetGymEntries();
            _usersMock = MockUsersProfileRepository.GetProfiles();
        }

        [Fact]
        public async Task GetWeekStats_CorrectData_ReturnsGymEntriesWeeklyStatsDTO()
        {
            var handler = new GetWeekStatsQueryHandler(_entriesMock.Object, _usersMock.Object);
            var result = await handler.Handle(new GetWeekStatsQuery { profileId = Guid.Parse("00000000-0000-0000-0000-000000000001") }, CancellationToken.None);
            result.ShouldBeOfType<GymEntriesWeeklyStatsDTO>();
        }

        [Fact]
        public void GetWeekStats_InvalidProfileId_ThrowsNotFound()
        {
            var handler = new GetWeekStatsQueryHandler(_entriesMock.Object, _usersMock.Object);
            Should.Throw<NotFoundException>(async () =>
            {
                await handler.Handle(new GetWeekStatsQuery { profileId = Guid.Parse("00000000-0000-0000-0000-000000100001") }, CancellationToken.None);
            });
        }

    }
}
