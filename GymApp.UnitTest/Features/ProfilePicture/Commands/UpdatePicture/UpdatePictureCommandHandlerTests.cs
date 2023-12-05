using GymApp.Application.Exceptions;
using GymApp.Application.Features.ProfilePicture.Commands.UpdatePicture;
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

namespace GymApp.UnitTests.Features.ProfilePicture.Commands.UpdatePicture
{
    public class UpdatePictureCommandHandlerTests
    {
        private readonly Mock<IProfilePictureRepository> _picturesMock;

        public UpdatePictureCommandHandlerTests()
        {
            _picturesMock = MockProfilePictureRepository.GetPictures();
        }

        [Fact]
        public async Task UpdateDefaultPicture_CorrectData_ReturnGuid()
        {
            var handler = new UpdatePictureCommandHandler(_picturesMock.Object);
            var result = await handler.Handle(new UpdatePictureCommand { Content = new byte[] { 3, 2, 3 }, Id = Guid.Parse("00000000-0000-0000-0000-000000000001") }, CancellationToken.None);
            result.ShouldNotBe(Guid.Parse("00000000-0000-0000-0000-000000000001"));
        }

        [Fact]
        public async Task UpdateCustomPicture_CorrectData_ReturnGuid()
        {
            var handler = new UpdatePictureCommandHandler(_picturesMock.Object);
            var result = await handler.Handle(new UpdatePictureCommand { Content = new byte[] { 3, 2, 3 }, Id = Guid.Parse("00000000-0000-0000-0000-000000000002") }, CancellationToken.None);
            result.ShouldBe(Guid.Parse("00000000-0000-0000-0000-000000000002"));
        }

        [Fact]
        public void UpdatePicture_InvalidData_ThrowsNotFound()
        {
            var handler = new UpdatePictureCommandHandler(_picturesMock.Object);
            Should.Throw<NotFoundException>(async () =>
            {
                await handler.Handle(new UpdatePictureCommand { Content = new byte[] { 3, 2, 3 }, Id = Guid.Parse("00000000-0000-0000-0000-000000000012") }, CancellationToken.None);
            });
        }
    }
}
