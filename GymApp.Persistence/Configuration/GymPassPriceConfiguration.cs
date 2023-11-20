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
    public class GymPassPriceConfiguration : IEntityTypeConfiguration<GymPassPrice>
    {
        public void Configure(EntityTypeBuilder<GymPassPrice> builder)
        {
            builder.HasKey(a => a.Length);

            builder.HasData(
                new GymPassPrice
                {
                    Length = Domain.Enums.GymPassLength.Month,
                    Price = 99
                },
                new GymPassPrice 
                {
                    Length = Domain.Enums.GymPassLength.Quarter,
                    Price = 250
                },
                new GymPassPrice
                {
                    Length = Domain.Enums.GymPassLength.HalfYear,
                    Price = 450
                },
                new GymPassPrice
                {
                    Length = Domain.Enums.GymPassLength.Year,
                    Price = 850
                }
            );
        }
    }
}
