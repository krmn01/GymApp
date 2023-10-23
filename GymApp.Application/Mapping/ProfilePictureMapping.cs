using AutoMapper;
using GymApp.Application.Features.ApplicationUser.Queries.GetUsersData;
using GymApp.Application.Features.ProfilePicture;
using GymApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Mapping
{
    public class ProfilePictureMapping :Profile
    {
        public ProfilePictureMapping()
        {
            CreateMap<ProfilePictureDTO, ProfilePicture>().ReverseMap();
        }
    }
}
