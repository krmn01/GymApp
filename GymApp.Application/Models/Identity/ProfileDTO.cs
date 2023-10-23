using GymApp.Application.Features.ProfilePicture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Models.Identity
{
    public class ProfileDTO
    {
        public User User { get; set; }
        public ProfilePictureDTO ProfilePictureDTO { get; set; }
    }
}
