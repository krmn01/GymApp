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
    public class PersonalTrainerConfiguration : IEntityTypeConfiguration<PersonalTrainer>
    {
        public void Configure(EntityTypeBuilder<PersonalTrainer> builder)
        {
            builder.HasMany(a => a.Classes)
                   .WithOne(b => b.PersonalTrainer);

            builder.HasData(
              new PersonalTrainer
              {
                  Id = Guid.Parse("00000000-2199-8437-0000-000000000001"),
                  Name = "Łukasz",
                  Surname = "Karasek",
                  PhoneNumber = "533222111",
                  Email = "l.karasek@gmail.com",
              }
            );
        }
    }
}
