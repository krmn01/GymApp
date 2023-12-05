using AutoMapper;
using GymApp.Application.Exceptions;
using GymApp.Application.Features.ProfilePicture;
using GymApp.Application.Features.ProfilePicture.Queries.GetPicture;
using GymApp.Application.Features.UsersProfile.Commands.DeleteUsersProfile;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Application.Mapping;
using GymApp.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GymApp.UnitTests.Features.ProfilePicture.Queries
{
    public class GetPictureQueryHandlerTests
    {
        private readonly Mock<IProfilePictureRepository> _picturesMock;
        private readonly IMapper _mapper;

        public GetPictureQueryHandlerTests()
        {
            _picturesMock = MockProfilePictureRepository.GetPictures();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ProfilePictureMapping>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetPicture_CorrectData_ReturnsBase64()
        {
            var handler = new GetPictureQueryHandler(_mapper, _picturesMock.Object);
            var result = await handler.Handle(new GetPictureQuery { Id = Guid.Parse("00000000-0000-0000-0000-000000000001")}, CancellationToken.None);
            result.Content.ShouldBe("AQID");
        }

        [Fact]
        public void GetPicture_InvalidPicture_ThrowsNotFound()
        {
            var handler = new GetPictureQueryHandler(_mapper, _picturesMock.Object);
            Should.Throw<NotFoundException>(async () =>
            {
                await handler.Handle(new GetPictureQuery { Id = Guid.Parse("00000000-0000-0000-0000-000000000011") }, CancellationToken.None);
            });   
        }
    }
}
