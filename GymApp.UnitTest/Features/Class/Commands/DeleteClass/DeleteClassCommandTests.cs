using AutoMapper;
using GymApp.Application.Exceptions;
using GymApp.Application.Features.Class.Commands.AddClass;
using GymApp.Application.Features.Class.Commands.DeleteClass;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Application.Mapping;
using GymApp.UnitTests.Mock;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GymApp.UnitTests.Features.Class.Commands.DeleteClass
{
    public class DeleteClassCommandTests
    {
        private readonly Mock<IClassRepository> _classesMock;

        public DeleteClassCommandTests()
        {
            _classesMock = MockClassRepository.GetClasses();
        }

        [Fact]
        public async Task DeleteClass_CorrectData_ReturnUnit()
        {
            var handler = new DeleteClassCommandHandler(_classesMock.Object);
            var classId = Guid.Parse("00000000-0000-0000-0000-000000000001");
            
            await handler.Handle(new DeleteClassCommand { ClassId = classId }, CancellationToken.None);
            var repositoryCount = _classesMock.Object.GetAllAsync().Result;

            repositoryCount.Count.ShouldBe(2);
        }

        [Fact]
        public void DeleteClass_InvalidClassId_ThrowsNotFoundException()
        {
            var handler = new DeleteClassCommandHandler(_classesMock.Object);
            var classId = Guid.Parse("00000000-0000-0000-0000-000000000031");

            Should.Throw<NotFoundException>(async () => {
                await handler.Handle(new DeleteClassCommand { ClassId = classId }, CancellationToken.None);
            });
        }
    }
}
