using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.TrainingGoal.Commands.ToggleTrainingGoal
{
    public class ToggleTrainingGoalCommand : IRequest<Unit>
    {
        public Guid ProfileId { get; set; }
        public Guid TrainingGoalId { get; set; }
    }
}
