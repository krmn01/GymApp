using AutoMapper;
using GymApp.Application.Features.ApplicationUser.Queries.GetUsersData;
using GymApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Mapping
{
    public class UserMapping :Profile
    {
        public UserMapping()
        {
            CreateMap<ApplicationUserDTO,ApplicationUser>().ReverseMap();
        }
    }
}
