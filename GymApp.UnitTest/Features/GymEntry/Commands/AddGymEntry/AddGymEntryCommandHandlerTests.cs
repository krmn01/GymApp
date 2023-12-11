using GymApp.Application.Exceptions;
using GymApp.Application.Features.GymEntry.Commands.AddGymEntry;
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

namespace GymApp.UnitTests.Features.GymEntry.Commands.AddGymEntry
{
    public class AddGymEntryCommandHandlerTests
    {
        private readonly Mock<IGymEntryRepository> _entriesMock;
        private readonly Mock<IUsersProfileRepository> _usersMock;

        public AddGymEntryCommandHandlerTests()
        {
            _entriesMock = MockGymEntryRepository.GetGymEntries();
            _usersMock = MockUsersProfileRepository.GetProfiles();
        }

        [Fact]
        public async Task AddGymEntry_CorrectData_ReturnsGuid()
        {
            var handler = new AddGymEntryCommandHandler(_entriesMock.Object,_usersMock.Object);
            var result = await handler.Handle(new AddGymEntryCommand { profileId = Guid.Parse("00000000-0000-0000-0000-000000000001"), timeInMinutes = 60 }, CancellationToken.None);
            result.ShouldBeOfType<Guid>();
        }

        [Fact]
        public void AddGymEntry_InvalidTimeInMinutes_ThrowsBadRequest()
        {
            var handler = new AddGymEntryCommandHandler(_entriesMock.Object, _usersMock.Object);
            Should.Throw<BadRequestException>(async () =>
            {
                await handler.Handle(new AddGymEntryCommand { profileId = Guid.Parse("00000000-0000-0000-0000-000000000001"), timeInMinutes = -1 }, CancellationToken.None);
            });
        }

        [Fact]
        public void AddGymEntry_InvalidProfile_ThrowsBadRequest()
        {
            var handler = new AddGymEntryCommandHandler(_entriesMock.Object, _usersMock.Object);
            Should.Throw<NotFoundException>(async () =>
            {
                await handler.Handle(new AddGymEntryCommand { profileId = Guid.Parse("00000000-0000-0000-0000-000000000101"), timeInMinutes = 60 }, CancellationToken.None);
            });
        }
    }
}
