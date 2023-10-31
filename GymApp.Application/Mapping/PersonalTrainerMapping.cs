using AutoMapper;
using GymApp.Application.Features.Class;
using GymApp.Application.Features.PersonalTrainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Mapping
{
    public class PersonalTrainerMapping :Profile
    {
        public PersonalTrainerMapping()
        {
            CreateMap<Domain.Entities.Class, ClassDTO>();
            CreateMap<Domain.Entities.PersonalTrainer,PersonalTrainerDTO>()
                .ForMember(dest => dest.Classes, opt => opt.MapFrom(src => src.Classes));
        }
    }
}
