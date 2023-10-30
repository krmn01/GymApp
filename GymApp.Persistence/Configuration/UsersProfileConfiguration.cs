using GymApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Persistence.Configuration
{
    public class UsersProfileConfiguration : IEntityTypeConfiguration<UsersProfile>
    {
        public void Configure(EntityTypeBuilder<UsersProfile> builder)
        {
            builder.HasData(
               new UsersProfile
               {
                   Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                   TrainingGoals = new List<TrainingGoal>(),
                   Classes = new List<Class>(),
                   ProfileDescription = string.Empty,
                   ProfilePictureId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                   UsersId = "753caff9-598a-42d9-aa00-bfa3be83096a"
               },
                new UsersProfile
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    TrainingGoals = new List<TrainingGoal>(),
                    Classes = new List<Class>(),
                    ProfileDescription = string.Empty,
                    ProfilePictureId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    UsersId = "4a60b6be-42d4-4676-86ef-bbfe129011da"
                }
            );

            builder.HasMany(a => a.TrainingGoals)
                   .WithOne(b => b.Profile);

            builder.HasMany(a => a.Classes)
                   .WithMany(b => b.Users);

        }

    }
}
