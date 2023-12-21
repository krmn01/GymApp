using GymApp.Application.Features.ProfilePicture;
using GymApp.Application.Models.Identity;
using GymApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.UsersProfile
{
    public class ProfileDTO
    {
        public User User { get; set; }
        public ProfilePictureDTO ProfilePicture { get; set; }
    }
}
