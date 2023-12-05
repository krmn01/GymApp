using AutoMapper;
using GymApp.Application.Exceptions;
using GymApp.Application.Features.GymPass.Queries.GetGymPass;
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

namespace GymApp.UnitTests.Features.GymPass.Queries.GetGymPass
{
    public class GetGymPassQueryHandlerTests
    {
        private readonly Mock<IGymPassRepository> _passesMock;
        private readonly Mock<IUsersProfileRepository> _profilesMock;
        private readonly IMapper _mapper;

        public GetGymPassQueryHandlerTests()
        {
            _passesMock = MockGymPassRepository.GetGymPasses();
            _profilesMock = MockUsersProfileRepository.GetProfiles();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<GymPassMapping>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetGymPass_CorrectData_ReturnsGymPassDTO()
        {
            var handler = new GetGymPassQueryHandler(_mapper,_passesMock.Object,_profilesMock.Object);
            var result = await handler.Handle(new GetGymPassQuery { ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001") },CancellationToken.None);
            result.ShouldBeOfType<GymPassDTO>();
        }

        [Fact]
        public void GetGymPass_InvalidProfile_ThrowsNotFound()
        {
            var handler = new GetGymPassQueryHandler(_mapper, _passesMock.Object, _profilesMock.Object);
            Should.Throw<NotFoundException>(async () =>
            {
                await handler.Handle(new GetGymPassQuery { ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000101") }, CancellationToken.None);
            });      
        }
    }
}
