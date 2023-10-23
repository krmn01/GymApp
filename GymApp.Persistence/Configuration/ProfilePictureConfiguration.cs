using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Domain.Entities;

namespace GymApp.Persistence.Configuration
{
    public class ProfilePictureConfiguration : IEntityTypeConfiguration<ProfilePicture>
    {
        public void Configure(EntityTypeBuilder<ProfilePicture> builder)
        {
            builder.HasData(
                new ProfilePicture
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Picture = new byte[]
                    {
                        0,0,0,0,0,0,0,255,0,0,0,0,0
                    }
                }
             );
        }
    }
}
