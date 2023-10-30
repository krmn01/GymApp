using AutoMapper;
using GymApp.Application.Features.ProfilePicture;
using GymApp.Application.Features.TrainingGoal;
using GymApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Mapping
{
    public class TrainingGoalMapping :Profile
    {
        public TrainingGoalMapping()
        {
            CreateMap<TrainingGoalDTO, TrainingGoal>()
                    .ReverseMap();
        }
    }
}
