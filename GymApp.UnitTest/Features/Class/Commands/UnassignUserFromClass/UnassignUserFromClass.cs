using AutoMapper;
using GymApp.Application.Exceptions;
using GymApp.Application.Features.Class.Commands;
using GymApp.Application.Features.Class.Commands.UnassignClassFromUser;
using GymApp.Application.Interfaces.Persistence;
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

namespace GymApp.UnitTests.Features.Class.Commands.UnassignUserFromClass
{ 
    public class UnassignUserFromClass
    {
        private readonly Mock<IUsersProfileRepository> _profilesMock;
        private readonly Mock<IClassRepository> _classesMock;

        public UnassignUserFromClass()
        {
            _profilesMock = MockUsersProfileRepository.GetProfiles();
            _classesMock = MockClassRepository.GetClasses();
        }

        [Fact]
        public async Task UnassignFromUser_CorrectData_ReturnUnit()
        {
            var handler = new UnassignClassFromUserCommandHandler(_classesMock.Object, _profilesMock.Object);
            await handler.Handle(new UnassignClassFromClassCommand { ClassId = Guid.Parse("00000000-0000-0000-0000-000000000002"), ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000002") }, CancellationToken.None);
            var @class = _classesMock.Object.GetByIdAsync(Guid.Parse("00000000-0000-0000-0000-000000000001")).Result;

            @class.Users.Count.ShouldBe(0);
        }


        [Fact]
        public void UnassignFromUser_UserNotAssigned_ThrowsBadRequest()
        {
            var handler = new UnassignClassFromUserCommandHandler(_classesMock.Object, _profilesMock.Object);

            Should.Throw<BadRequestException>(async () => {
                await handler.Handle(new UnassignClassFromClassCommand{ ClassId = Guid.Parse("00000000-0000-0000-0000-000000000003"), ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000002") }, CancellationToken.None);
            });
        }

        [Fact]
        public void UnassignFromUser_InvalidUser_ThrowsNotFound()
        {
            var handler = new UnassignClassFromUserCommandHandler(_classesMock.Object, _profilesMock.Object);

            Should.Throw<NotFoundException>(async () => {
                await handler.Handle(new UnassignClassFromClassCommand { ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000011"), ClassId = Guid.Parse("00000000-0000-0000-0000-000000000003") }, CancellationToken.None);
            });
        }

        [Fact]
        public void UnassignFromUser_InvalidClass_ThrowsNotFound()
        {
            var handler = new UnassignClassFromUserCommandHandler(_classesMock.Object, _profilesMock.Object);

            Should.Throw<NotFoundException>(async () => {
                await handler.Handle(new UnassignClassFromClassCommand { ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001"), ClassId = Guid.Parse("00000000-0000-0000-0000-000000000013") }, CancellationToken.None);
            });
        }
    }
}
