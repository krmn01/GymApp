using AutoMapper;
using GymApp.Application.Features.TrainingGoal.Commands.AddTrainingGoal;
using GymApp.Application.Features.TrainingGoal;
using GymApp.Application.Interfaces.Persistence;
using GymApp.UnitTests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using GymApp.Application.Mapping;
using Shouldly;
using GymApp.Application.Features.PersonalTrainer.Commands.DeleteTrainer;
using GymApp.Application.Features.TrainingGoal.Commands.DeleteTrainingGoal;
using GymApp.Application.Exceptions;

namespace GymApp.UnitTests.Features.TrainingGoal.Commands.DeleteTrainingGoal
{
    public class DeleteTrainingGoalCommandHandlerTests
    {
        private readonly Mock<ITrainingGoalsRepository> _goalsMock;
        public DeleteTrainingGoalCommandHandlerTests()
        {
            _goalsMock = MockTrainingGoalRepository.GetGoals();
        }

        [Fact]
        public async Task DeleteTrainingGoal_CorrectData_ReturnGuid()
        {
            var handler = new DeleteTrainingGoalCommandHandler(_goalsMock.Object);
            await handler.Handle(new DeleteTrainingGoalCommand { ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001"),TrainingGoalId = Guid.Parse("00000000-0000-0000-0000-000000000001") }, CancellationToken.None);
            var goals = _goalsMock.Object.GetAllAsync().Result;
            goals.Count.ShouldBe(2);
        }

        [Fact]
        public void DeleteTrainingGoal_IncorrectProfileId_ThrowsBadRequest()
        {
            var handler = new DeleteTrainingGoalCommandHandler(_goalsMock.Object);
            Should.Throw<BadRequestException>(async () =>
            {
                await handler.Handle(new DeleteTrainingGoalCommand { ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000002"), TrainingGoalId = Guid.Parse("00000000-0000-0000-0000-000000000001") }, CancellationToken.None);
            });
        }

        [Fact]
        public void DeleteTrainingGoal_IncorrectGoalId_ThrowsNotFound()
        {
            var handler = new DeleteTrainingGoalCommandHandler(_goalsMock.Object);
            Should.Throw<NotFoundException>(async () =>
            {
                await handler.Handle(new DeleteTrainingGoalCommand { ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001"), TrainingGoalId = Guid.Parse("00000000-0000-0000-0000-000000000021") }, CancellationToken.None);
            });
        }
    }
}
