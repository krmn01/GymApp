using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.TrainingGoal
{
    public class TrainingGoalDTO
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public bool Finished { get; set; }
    }
}
