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
    public class GymPassConfiguration : IEntityTypeConfiguration<GymPass>
    {
        public void Configure(EntityTypeBuilder<GymPass> builder)
        {
            builder.HasData(
                new GymPass
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    ValidTill = DateTime.Now,
                    StartedOn = DateTime.Now,
                    ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                },
                 new GymPass
                 {
                     Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                     ValidTill = DateTime.Now,
                     StartedOn = DateTime.Now,
                     ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                 }
            );

            builder.HasOne(a => a.Profile)
                    .WithOne(b => b.Pass);
                   
        }
    }
}
