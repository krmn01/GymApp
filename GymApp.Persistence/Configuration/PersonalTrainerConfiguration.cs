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
                  Classes = new List<Class>()
              },
              new PersonalTrainer
              {
                  Id = Guid.Parse("12340008-2199-8437-0000-000000003331"),
                  Name = "Mateusz",
                  Surname = "Kołtuniuk",
                  PhoneNumber = "666222111",
                  Email = "m.koltuniuk@gmail.com",
                  Classes = new List<Class>()
              },
              new PersonalTrainer
              {
                  Id = Guid.Parse("33300000-2137-8437-0000-045600000001"),
                  Name = "Kamil",
                  Surname = "Kończyński",
                  PhoneNumber = "533444111",
                  Email = "k.konczyński@gmail.com",
                  Classes = new List<Class>()
              }
            );
        }
    }
}
