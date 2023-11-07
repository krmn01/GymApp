using AutoMapper;
using GymApp.Application.Features.GymPass.Requests.GetGymPass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Mapping
{
    public class GymPassMapping :Profile
    {
        public GymPassMapping()
        {
            CreateMap<Domain.Entities.GymPass, GymPassDTO>()
                .ForMember(dest => dest.QrCode, opt => opt.Ignore());
        }
    }
}
