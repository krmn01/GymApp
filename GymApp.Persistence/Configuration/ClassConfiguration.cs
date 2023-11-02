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
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasMany(a => a.Users)
                   .WithMany(b => b.Classes);

            builder.HasOne(a => a.PersonalTrainer)
                   .WithMany(b => b.Classes)
                   .HasForeignKey(b => b.PersonalTrainerId);

            builder.HasData(
                  new Class
                  {
                      Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                      ClassName = "Żelazne barki",
                      Users = new List<UsersProfile>(),
                      PersonalTrainerId = Guid.Parse("00000000-2199-8437-0000-000000000001"),
                      StartTime = new DateTime(2023, 6, 15, 21, 15, 00),
                      EndTime = new DateTime(2023, 6, 15, 22, 00, 00),
                      DayOfWeek = Domain.Enums.DaysOfWeek.monday,
                      MaxUsers = 20
                  },
                  new Class
                  {
                      Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                      ClassName = "Klatka piersiowa",
                      Users = new List<UsersProfile>(),
                      PersonalTrainerId = Guid.Parse("00000000-2199-8437-0000-000000000001"),
                      StartTime = new DateTime(2023, 6, 15, 11, 15, 00),
                      EndTime = new DateTime(2023, 6, 15, 12, 00, 00),
                      DayOfWeek = Domain.Enums.DaysOfWeek.tuesday,
                      MaxUsers = 20
                  },
                  new Class
                  {
                      Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                      ClassName = "Brzuch jak kaloryfer",
                      Users = new List<UsersProfile>(),
                      PersonalTrainerId = Guid.Parse("12340008-2199-8437-0000-000000003331"),
                      StartTime = new DateTime(2023, 6, 15, 13, 15, 00),
                      EndTime = new DateTime(2023, 6, 15, 14, 00, 00),
                      DayOfWeek = Domain.Enums.DaysOfWeek.monday,
                      MaxUsers = 20
                  },
                   new Class
                   {
                       Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                       ClassName = "Brazylijskie pośladki",
                       Users = new List<UsersProfile>(),
                       PersonalTrainerId = Guid.Parse("12340008-2199-8437-0000-000000003331"),
                       StartTime = new DateTime(2023, 6, 15, 10, 15, 00),
                       EndTime = new DateTime(2023, 6, 15, 11, 00, 00),
                       DayOfWeek = Domain.Enums.DaysOfWeek.thursday,
                       MaxUsers = 20
                   },
                    new Class
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        ClassName = "Zumba fitness",
                        Users = new List<UsersProfile>(),
                        PersonalTrainerId = Guid.Parse("33300000-2137-8437-0000-045600000001"),
                        StartTime = new DateTime(2023, 6, 15, 16, 15, 00),
                        EndTime = new DateTime(2023, 6, 15, 17, 00, 00),
                        DayOfWeek = Domain.Enums.DaysOfWeek.friday,
                        MaxUsers = 15
                    },
                     new Class
                     {
                         Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                         ClassName = "Crossfit",
                         Users = new List<UsersProfile>(),
                         PersonalTrainerId = Guid.Parse("33300000-2137-8437-0000-045600000001"),
                         StartTime = new DateTime(2023, 6, 15, 18, 15, 00),
                         EndTime = new DateTime(2023, 6, 15, 19, 00, 00),
                         DayOfWeek = Domain.Enums.DaysOfWeek.wednesday,
                         MaxUsers = 10
                     }
            );
        }
    }
}
