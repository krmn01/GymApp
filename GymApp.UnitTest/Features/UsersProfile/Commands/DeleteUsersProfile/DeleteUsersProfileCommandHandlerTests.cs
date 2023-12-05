using GymApp.Application.Exceptions;
using GymApp.Application.Features.UsersProfile.Commands.CreateUsersProfile;
using GymApp.Application.Features.UsersProfile.Commands.DeleteUsersProfile;
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

namespace GymApp.UnitTests.Features.UsersProfile.Commands.DeleteUsersProfile
{
    public class DeleteUsersProfileCommandHandlerTests
    {
        private readonly Mock<IUsersProfileRepository> _profilesMock;

        public DeleteUsersProfileCommandHandlerTests()
        {
            _profilesMock = MockUsersProfileRepository.GetProfiles();
        }

        [Fact]
        public async Task DeleteProfile_CorrectData_ReturnsGuid()
        {
            var handler = new DeleteUsersProfileCommandHandler(_profilesMock.Object);
            await handler.Handle(new DeleteUsersProfileCommand { ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001")}, CancellationToken.None);
            var profiles = _profilesMock.Object.GetAllAsync().Result;
            profiles.Count.ShouldBe(2);
        }

        [Fact]
        public void DeleteProfile_InvalidProfile_ThrowsNotFound()
        {
            var handler = new DeleteUsersProfileCommandHandler(_profilesMock.Object);
            Should.Throw<NotFoundException>(async () =>
            {
                await handler.Handle(new DeleteUsersProfileCommand { ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000011") }, CancellationToken.None);
            }); 
        }
    }
}
