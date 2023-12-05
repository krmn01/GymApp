using AutoMapper;
using GymApp.Application.Features.Class;
using GymApp.Application.Features.Class.Commands.UnassignClassFromUser;
using GymApp.Application.Features.Class.Queries.GetUsersClasses;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Application.Mapping;
using GymApp.UnitTests.Mock;
using GymApp.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GymApp.UnitTests.Features.Class.Queries.GetUsersClasses
{
    public class GetUsersClassesQueryHandlerTests
    {
        private readonly Mock<IUsersProfileRepository> _profilesMock;
        private readonly Mock<IClassRepository> _classesMock;
        private readonly IMapper _mapper;

        public GetUsersClassesQueryHandlerTests()
        {
            _profilesMock = MockUsersProfileRepository.GetProfiles();
            _classesMock = MockClassRepository.GetClasses();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ClassMapping>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetUsersClasses_null_ReturnUnit()
        {
            var handler = new GetUsersClassesQueryHandler(_mapper,_classesMock.Object);
            var result = await handler.Handle(new GetUsersClassesQuery { ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000002") }, CancellationToken.None);

            result.Count.ShouldBe(1);
        }
    }
}
