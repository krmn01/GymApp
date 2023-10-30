using GymApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Domain.Entities
{
    public class TrainingGoal :BaseEntity
    {
        public string Content { get; set; }
        public bool Finished { get; set; }

        [ForeignKey("ProfileId")]
        public Guid ProfileId { get; set; }
        public UsersProfile Profile { get; set; }

    }
}
