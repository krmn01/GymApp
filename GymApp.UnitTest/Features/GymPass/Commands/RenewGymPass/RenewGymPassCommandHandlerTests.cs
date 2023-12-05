using GymApp.Application.Exceptions;
using GymApp.Application.Features.GymPass.Commands.RenewGymPass;
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

namespace GymApp.UnitTests.Features.GymPass.Commands.RenewGymPass
{
    public class RenewGymPassCommandHandlerTests
    {
        private readonly Mock<IGymPassRepository> _passesMock;
        private readonly Mock<IUsersProfileRepository> _usersProfileMock;

        public RenewGymPassCommandHandlerTests()
        {
            _passesMock = MockGymPassRepository.GetGymPasses();
            _usersProfileMock = MockUsersProfileRepository.GetProfiles();
        }

        [Fact]
        public async Task RenewGymPass_CorrectData_ReturnsGuid()
        {
            var handler = new RenewGymPassCommandHandler(_passesMock.Object,_usersProfileMock.Object);
            var result = await handler.Handle(new RenewGymPassCommand { NumberOfDays = 30, ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001") }, CancellationToken.None);
            result.ShouldBeOfType<Guid>();
        }

        [Fact]
        public void RenewGymPass_IncorrectProfileId_ThrowsNotFound()
        {
            var handler = new RenewGymPassCommandHandler(_passesMock.Object, _usersProfileMock.Object);
            Should.Throw<NotFoundException>(async () =>
            {
                await handler.Handle(new RenewGymPassCommand { NumberOfDays = 30, ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000021") }, CancellationToken.None);
            });   
        }
    }
}
