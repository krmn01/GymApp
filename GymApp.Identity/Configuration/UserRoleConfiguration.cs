using GymApp.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "crcl3317-2222-4445-beef-1add431fcrcl",
                    UserId = "753caff9-598a-42d9-aa00-bfa3be83096a"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "crcl2137-2222-4448-beef-1add431acrcl",
                    UserId = "4a60b6be-42d4-4676-86ef-bbfe129011da"
                }
             );

        }
    }
}
