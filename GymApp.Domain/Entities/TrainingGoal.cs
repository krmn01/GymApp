using GymApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Domain.Entities
{
    public class TrainingGoal :BaseEntity
    {
        public string Content { get; set; }
        public bool Finished { get; set; }


    }
}
