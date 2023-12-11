using GymApp.Application.Features.GymEntry;
using GymApp.Application.Features.GymEntry.Queries.GetWeekStats;
using GymApp.Application.Features.GymEntry.Queries.GetWeekStatsRank;
using GymApp.Application.Interfaces.Identity;
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

namespace GymApp.UnitTests.Features.GymEntry.Queries.GetWeekStatsRank
{
    public class GetWeekStatsRankQueryHandlerTests
    {
        private readonly Mock<IGymEntryRepository> _entriesMock;
        private readonly Mock<IUsersProfileRepository> _usersMock;
        private readonly Mock<IProfilePictureRepository> _pcituresMock;
        private readonly Mock<IUserService> _userServiceMock;

        public GetWeekStatsRankQueryHandlerTests()
        {
            _entriesMock = MockGymEntryRepository.GetGymEntries();
            _usersMock = MockUsersProfileRepository.GetProfiles();
            _pcituresMock = MockProfilePictureRepository.GetPictures();
            _userServiceMock = MockUserService.UserServiceMock();
        }

        [Fact]
        public async Task GetWeekStatsRank_CorrectData_ReturnListOfStatDTO()
        {
            var handler = new GetWeekStatsRankQueryHandler(_entriesMock.Object, _pcituresMock.Object, _usersMock.Object, _userServiceMock.Object);
            var result = await handler.Handle(new GetWeekStatsRankQuery { },CancellationToken.None);
            result.ShouldBeOfType<List<GymEntriesWeeklyStatsDTO>>();
        }
    }
}
