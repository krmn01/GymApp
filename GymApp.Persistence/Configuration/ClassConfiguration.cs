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
                      MaxUsers = 20
                  }
            );
        }
    }
}
