using GymApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Domain.Entities
{
    public class UsersProfile  : BaseEntity
    {
        public string UsersId { get; set; }
        public IEnumerable<TrainingGoal> TrainingGoals { get; set; }
        public IEnumerable<Class> Classes { get; set; }
        public Guid ProfilePictureId { get; set; }
        public string ProfileDescription { get; set; }
        public GymPass Pass { get; set; }
    }
}
