using AutoMapper;
using GymApp.Application.Features.GymPass.Queries.GetGymPassPrices;
using GymApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Mapping
{
    public class GymPassPriceMapping : Profile
    {
        public GymPassPriceMapping()
        {
            CreateMap<GymPassPrice,GymPassPriceDTO>()
                .ForMember(dest => dest.Length, o => o.MapFrom(src =>  src.Length))
                .ForMember(dest => dest.Price, o => o.MapFrom(src => src.Price));
        }
    }
}
