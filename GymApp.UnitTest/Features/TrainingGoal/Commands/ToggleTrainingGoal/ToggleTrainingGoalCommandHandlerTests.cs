using GymApp.Application.Exceptions;
using GymApp.Application.Features.TrainingGoal.Commands.DeleteTrainingGoal;
using GymApp.Application.Features.TrainingGoal.Commands.ToggleTrainingGoal;
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

namespace GymApp.UnitTests.Features.TrainingGoal.Commands.ToggleTrainingGoal
{
    public class ToggleTrainingGoalCommandHandlerTests
    {
        private readonly Mock<ITrainingGoalsRepository> _goalsMock;
        public ToggleTrainingGoalCommandHandlerTests()
        {
            _goalsMock = MockTrainingGoalRepository.GetGoals();
        }

        [Fact]
        public async Task ToggleTrainingGoal_CorrectData_ReturnGuid()
        {
            var handler = new ToggleTrainingGoalCommandHandler(_goalsMock.Object);
            await handler.Handle(new ToggleTrainingGoalCommand { ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001"), TrainingGoalId = Guid.Parse("00000000-0000-0000-0000-000000000001") }, CancellationToken.None);
            var goal = _goalsMock.Object.GetByIdAsync(Guid.Parse("00000000-0000-0000-0000-000000000001")).Result;
            goal.Finished.ShouldBeTrue();
        }

        [Fact]
        public void ToggleTrainingGoal_IncorrectProfileId_ThrowsBadRequest()
        {
            var handler = new ToggleTrainingGoalCommandHandler(_goalsMock.Object);
            Should.Throw<BadRequestException>(async () =>
            {
                await handler.Handle(new ToggleTrainingGoalCommand { ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000002"), TrainingGoalId = Guid.Parse("00000000-0000-0000-0000-000000000001") }, CancellationToken.None);
            });
        }

        [Fact]
        public void ToggleTrainingGoal_IncorrectGoalId_ThrowsNotFound()
        {
            var handler = new ToggleTrainingGoalCommandHandler(_goalsMock.Object);
            Should.Throw<NotFoundException>(async () =>
            {
                await handler.Handle(new ToggleTrainingGoalCommand { ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001"), TrainingGoalId = Guid.Parse("00000000-0000-0000-0000-000000000021") }, CancellationToken.None);
            });
        }
    }
}
