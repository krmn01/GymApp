using AutoMapper;
using GymApp.Application.Features.TrainingGoal;
using GymApp.Application.Features.TrainingGoal.GetAllTrainingGoals;
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

namespace GymApp.UnitTests.Features.TrainingGoal.Queries
{
    public class GetAllTrainingGoalsQueryTests
    {
        private readonly Mock<ITrainingGoalsRepository> _goalsMock;
        private readonly IMapper _mapper;

        public GetAllTrainingGoalsQueryTests()
        {
            _goalsMock = MockTrainingGoalRepository.GetGoals();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<TrainingGoalMapping>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetAllTrainingGoals_CorrectData_ReturnsTrainingGoalList()
        {
            var handler = new GetAllTrainingGoalsQueryHandler(_mapper,_goalsMock.Object);
            var result = await handler.Handle(new GetAllTrainingGoalsQuery { ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001") },CancellationToken.None);
            result.ShouldBeOfType<List<TrainingGoalDTO>>();
        }
    }
}
