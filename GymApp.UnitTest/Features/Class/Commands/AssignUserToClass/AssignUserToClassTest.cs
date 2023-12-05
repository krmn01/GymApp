using AutoMapper;
using GymApp.Application.Exceptions;
using GymApp.Application.Features.Class.Commands;
using GymApp.Application.Features.Class.Commands.AddClass;
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

namespace GymApp.UnitTests.Features.Class.Commands.AssignUserToClass
{
    public class AssignUserToClassTest
    {
        private readonly Mock<IUsersProfileRepository> _profilesMock;
        private readonly Mock<IClassRepository> _classesMock;
        private readonly IMapper _mapper;

        public AssignUserToClassTest()
        {
            _profilesMock = MockUsersProfileRepository.GetProfiles();
            _classesMock = MockClassRepository.GetClasses();
        }

        [Fact]
        public async Task AssignToUser_CorrectData_ReturnUnit()
        {
            var handler = new UnassignUserFromClassCommandHandler(_classesMock.Object, _profilesMock.Object);
            await handler.Handle(new UnassignUserFromClassCommand { UserProfileId = Guid.Parse("00000000-0000-0000-0000-000000000002"), ClassId = Guid.Parse("00000000-0000-0000-0000-000000000001") }, CancellationToken.None);
            var @class = _classesMock.Object.GetByIdAsync(Guid.Parse("00000000-0000-0000-0000-000000000001")).Result;

           @class.Users.Count.ShouldBe(1);
        }


        [Fact]
        public void AssignToUser_UserAlreadyAssigned_ThrowsBadRequest()
        {
            var handler = new UnassignUserFromClassCommandHandler(_classesMock.Object, _profilesMock.Object);
          
            Should.Throw<BadRequestException>(async () => {
                await handler.Handle(new UnassignUserFromClassCommand { UserProfileId = Guid.Parse("00000000-0000-0000-0000-000000000002"), ClassId = Guid.Parse("00000000-0000-0000-0000-000000000002") }, CancellationToken.None);
            });
        }

        [Fact]
        public void AssignToUser_ReachedMaxUsers_ThrowsBadRequest()
        {
            var handler = new UnassignUserFromClassCommandHandler(_classesMock.Object, _profilesMock.Object);

            Should.Throw<BadRequestException>(async () => {
                await handler.Handle(new UnassignUserFromClassCommand { UserProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001"), ClassId = Guid.Parse("00000000-0000-0000-0000-000000000003") }, CancellationToken.None);
            });
        }
    }
}
