using AutoMapper;
using GymApp.Application.Features.Class;
using GymApp.Application.Features.PersonalTrainer;
using GymApp.Application.Features.PersonalTrainer.Commands.CreateNewTrainer;
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

            CreateMap<NewTrainerDTO, Domain.Entities.PersonalTrainer>()
                .ForMember(x => x.Classes, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.CreatedOn, opt => opt.Ignore())
                .ForMember(x => x.UpdatedOn, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Domain.Entities.PersonalTrainer,PersonalTrainerDTO>()
                .ForMember(dest => dest.Classes, opt => opt.MapFrom(src => src.Classes));
        }
    }
}
