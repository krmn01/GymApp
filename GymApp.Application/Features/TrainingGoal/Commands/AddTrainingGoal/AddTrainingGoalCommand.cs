using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.TrainingGoal.Commands.AddTrainingGoal
{
    public class AddTrainingGoalCommand :IRequest<Guid>
    {
        public Guid ProfileId { get; set; }
        public TrainingGoalDTO TrainingGoalDTO { get; set; }
    }
}
