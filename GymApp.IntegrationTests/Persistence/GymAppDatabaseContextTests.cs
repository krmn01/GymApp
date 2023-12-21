using GymApp.Domain.Entities;
using GymApp.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GymApp.IntegrationTests.Persistence
{
    public class GymAppDatabaseContextTests
    {
        private readonly GymDatabaseContext _gymDatabaseContext;
        public GymAppDatabaseContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<GymDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _gymDatabaseContext = new GymDatabaseContext(dbOptions);
        }

        [Fact]
        public async Task Save_SetCreatedDateValue()
        {
            TrainingGoal trainingGoal = new TrainingGoal
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Content = "Test",
                Finished = false,
            };

            await _gymDatabaseContext.TrainingGoals.AddAsync(trainingGoal);
            await _gymDatabaseContext.SaveChangesAsync();

            trainingGoal.CreatedOn.ShouldNotBeNull();
        }

        [Fact]
        public async Task Save_SetModifiedDateValue()
        {
            TrainingGoal trainingGoal = new TrainingGoal
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Content = "Test",
                Finished = false,
            };

            await _gymDatabaseContext.TrainingGoals.AddAsync(trainingGoal);
            await _gymDatabaseContext.SaveChangesAsync();
            
            trainingGoal.UpdatedOn.ShouldNotBeNull();
        }

        [Fact]
        public async Task Update_SetModifiedDateValue()
        {
            TrainingGoal trainingGoal = new TrainingGoal
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Content = "Test",
                Finished = false,
            };

            await _gymDatabaseContext.TrainingGoals.AddAsync(trainingGoal);
            await _gymDatabaseContext.SaveChangesAsync();

            var currentDate = trainingGoal.UpdatedOn;
            trainingGoal.Content = "Test2";

            _gymDatabaseContext.TrainingGoals.Update(trainingGoal);
            await _gymDatabaseContext.SaveChangesAsync();

            trainingGoal.UpdatedOn.ShouldNotBe(currentDate);
        }

    }
}
