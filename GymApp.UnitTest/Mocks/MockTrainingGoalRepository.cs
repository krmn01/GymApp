using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.UnitTests.Mocks
{
    public class MockTrainingGoalRepository
    {
        public static Mock<ITrainingGoalsRepository> GetGoals()
        {
            var goals = new List<TrainingGoal>
            {
              new TrainingGoal
              {
                  Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                  ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                  Content = "Test",
                  Finished = false,
              },
              new TrainingGoal
              {
                  Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                  ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                  Content = "Test2",
                  Finished = false,
              },
              new TrainingGoal
              {
                  Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                  ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                  Content = "Test3",
                  Finished = false,
              },
            };

            var mockRepository = new Mock<ITrainingGoalsRepository>();

            mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(goals);

            mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).Returns((Guid id) =>
            {
                try
                {
                    var result = goals.Where(c => c.Id == id).First();
                    return Task.FromResult(result);
                }
                catch
                {
                    TrainingGoal result = null;
                    return Task.FromResult(result);
                }
            });

            mockRepository.Setup(r => r.CreateAsync(It.IsAny<TrainingGoal>()))
                .Returns((TrainingGoal c) =>
                {
                    goals.Add(c);
                    return Task.CompletedTask;
                });

            mockRepository.Setup(r => r.UpdateAsync(It.IsAny<TrainingGoal>())).Returns((TrainingGoal c) =>
            {
                var entry = goals.Where(x => x.Id == c.Id).First();
                entry = c;
                return Task.CompletedTask;
            });

            mockRepository.Setup(r => r.DeleteAsync(It.IsAny<TrainingGoal>())).Returns((TrainingGoal c) =>
            {
                goals.Remove(c);
                return Task.CompletedTask;
            });


            return mockRepository;

        }
    }
}
