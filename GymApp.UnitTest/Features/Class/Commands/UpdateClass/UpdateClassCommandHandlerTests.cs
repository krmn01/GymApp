using GymApp.Application.Exceptions;
using GymApp.Application.Features.Class.Commands.UpdateClass;
using GymApp.Application.Interfaces.Persistence;
using GymApp.UnitTests.Mock;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GymApp.UnitTests.Features.Class.Commands.UpdateClass
{
    public class UpdateClassCommandHandlerTests
    {
        private readonly Mock<IClassRepository> _classesMock;

        public UpdateClassCommandHandlerTests()
        {
            _classesMock = MockClassRepository.GetClasses();  
        }

        [Fact]
        public async Task UpdateClass_ClassName_ReturnsUnit()
        {
            var updatedClass = new UpdateClassDTO
            {
                ClassName = "Updated Name"
            };

            var handler = new UpdateClassCommandHandler(_classesMock.Object);
            await handler.Handle(new UpdateClassCommand { ClassId = Guid.Parse("00000000-0000-0000-0000-000000000002"), UpdatedClass = updatedClass}, CancellationToken.None);
            var @class = await _classesMock.Object.GetByIdAsync(Guid.Parse("00000000-0000-0000-0000-000000000002"));
            @class.ClassName.ShouldBe("Updated Name");
        }

        [Fact]
        public void UpdateClass_InvalidClass_ThrowsNotFound()
        {
            var handler = new UpdateClassCommandHandler(_classesMock.Object);
            Should.Throw<NotFoundException>(async () =>
            {
                await handler.Handle(new UpdateClassCommand { ClassId = Guid.Parse("00000000-0000-0000-0000-000000000012"), UpdatedClass = new UpdateClassDTO { } }, CancellationToken.None);
            });  
        }

    }
}
