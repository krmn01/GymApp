using GymApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.TrainingGoal.GetAllTrainingGoals
{
    public class GetAllTrainingGoalsQuery :IRequest<List<TrainingGoalDTO>>
    {
        public Guid ProfileId { get; set; }
    }
}
