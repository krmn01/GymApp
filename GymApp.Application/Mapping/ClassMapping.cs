using AutoMapper;
using GymApp.Application.Features.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Mapping
{
    public class ClassMapping :Profile
    {
        public ClassMapping() 
        {
            CreateMap<ClassDTO, Domain.Entities.Class>()
                .ForMember(dest => dest.StartTime, o => o.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndTime, o => o.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.DayOfWeek, o => o.MapFrom(src => src.DayOfWeek))
                .ReverseMap();

        }
    }
}
