using AutoMapper;
using GymApp.Application.Features.TrainingGoal;
using GymApp.Application.Features.TrainingGoal.Commands.AddTrainingGoal;
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

namespace GymApp.UnitTests.Features.TrainingGoal.Commands.AddTrainingGoal
{
    public class AddTrainingGoalCommandHandlerTests
    {
        private readonly Mock<ITrainingGoalsRepository> _goalsMock;
        private readonly IMapper _mapper;

        public AddTrainingGoalCommandHandlerTests()
        {
            _goalsMock = MockTrainingGoalRepository.GetGoals();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<TrainingGoalMapping>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task AddTrainingGoal_CorrectData_ReturnGuid()
        {
            var handler = new AddTrainingGoalCommandHandler(_mapper, _goalsMock.Object);
            var result = await handler.Handle(new AddTrainingGoalCommand { ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001"), TrainingGoalDTO = new TrainingGoalDTO { Content = "Abcdef", Finished = false, Id = new Guid() } }, CancellationToken.None);
            result.ShouldBeOfType<Guid>();
        }
    }
}
