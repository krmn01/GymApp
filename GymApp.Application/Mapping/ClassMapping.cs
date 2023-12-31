﻿using AutoMapper;
using GymApp.Application.Features.Class;
using GymApp.Application.Features.Class.Commands.AddClass;
using GymApp.Application.Features.Class.Commands.UpdateClass;
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
                .ForMember(dest => dest.PersonalTrainerId, o => o.MapFrom(src => src.TrainerId));

            CreateMap<AddClassDTO, Domain.Entities.Class>()
                .ForMember(dest => dest.StartTime, o => o.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndTime, o => o.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.DayOfWeek, o => o.MapFrom(src => src.DayOfWeek))
                .ForMember(dest => dest.PersonalTrainerId, o => o.MapFrom(src => src.TrainerId));

            CreateMap<UpdateClassDTO, Domain.Entities.Class>()
                .ForMember(dest => dest.StartTime, o => o.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndTime, o => o.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.DayOfWeek, o => o.MapFrom(src => src.DayOfWeek))
                .ForMember(dest => dest.PersonalTrainerId, o => o.MapFrom(src => src.TrainerId))
                .ForMember(dest => dest.ClassName, o => o.MapFrom(src => src.ClassName))
                .ForMember(dest => dest.MaxUsers, o => o.MapFrom(src => src.MaxUsers));

            CreateMap<Domain.Entities.Class, ClassDTO>()
                .ForMember(dest => dest.StartTime, o => o.MapFrom(src => src.StartTime.ToString("HH:mm")))
                .ForMember(dest => dest.EndTime, o => o.MapFrom(src => src.EndTime.ToString("HH:mm")))
                .ForMember(dest => dest.DayOfWeek, o => o.MapFrom(src => src.DayOfWeek))
                .ForMember(dest => dest.UsersCount, o => o.MapFrom(src => src.Users.Count))
                .ForMember(dest => dest.TrainerId, o => o.MapFrom(src => src.PersonalTrainerId));

        }
    }
}
