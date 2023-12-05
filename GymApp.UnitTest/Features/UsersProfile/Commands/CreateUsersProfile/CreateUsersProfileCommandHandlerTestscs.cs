using GymApp.Application.Features.UsersProfile.Commands.CreateUsersProfile;
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

namespace GymApp.UnitTests.Features.UsersProfile.Commands.CreateUsersProfile
{
    public class CreateUsersProfileCommandHandlerTestscs
    {
        private readonly Mock<IUsersProfileRepository> _profilesMock;

        public CreateUsersProfileCommandHandlerTestscs()
        {
            _profilesMock = MockUsersProfileRepository.GetProfiles();
        }

        [Fact]
        public async Task CreateProfile_CorrectData_ReturnsGuid()
        {
            var handler = new CreateUsersProfileCommandHandler(_profilesMock.Object);
            var result = await handler.Handle(new CreateUsersProfileCommand { ProfilePictureId = Guid.Parse("00000000-0000-0000-0000-000000000001"), UserId = "00000000-0000-0000-0000-000000000001" },CancellationToken.None);
            result.ShouldBeOfType<Guid>();
        }
    }
}
