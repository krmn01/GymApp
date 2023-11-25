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
        private byte[] GetDefaultPicture()
        {
            string pictureBase64 = "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";
            return Convert.FromBase64String(pictureBase64);
        }

        public void Configure(EntityTypeBuilder<ProfilePicture> builder)
        {
            builder.HasData(
                new ProfilePicture
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Picture = GetDefaultPicture()
                }
             );
        }
    }
}
