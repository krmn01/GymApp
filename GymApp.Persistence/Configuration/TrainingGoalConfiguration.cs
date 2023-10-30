using GymApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Persistence.Configuration
{
    public class TrainingGoalConfiguration : IEntityTypeConfiguration<TrainingGoal>
    {
        public void Configure(EntityTypeBuilder<TrainingGoal> builder)
        {
            builder.HasOne(a => a.Profile)
                   .WithMany(b => b.TrainingGoals);
        }
    }
}
