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
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hash = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "753caff9-598a-42d9-aa00-bfa3be83096a",
                    Email = "adm@adm.pl",
                    NormalizedEmail = "ADM@ADM.PL",
                    FullName = "Admin Admin",
                    UserName = "Administrator",
                    NormalizedUserName = "ADMINISTRATOR",
                    PasswordHash = hash.HashPassword(null, "Password1!"),
                    EmailConfirmed = true,
                    ProfilePictureId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                },
                 new ApplicationUser
                 {
                     Id = "4a60b6be-42d4-4676-86ef-bbfe129011da",
                     Email = "usr1@usr.pl",
                     NormalizedEmail = "USR1@USR.PL",
                     FullName = "Test User",
                     UserName = "TestUser",
                     NormalizedUserName = "TESTUSER",
                     PasswordHash = hash.HashPassword(null, "Password1!"),
                     EmailConfirmed = true,
                     ProfilePictureId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                 }

            );
        }
    }
}
