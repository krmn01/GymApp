using GymApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Domain.Entities
{
    public class Class :BaseEntity
    {
        public List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
        public PersonalTrainer PersonalTrainer { get; set; } = new PersonalTrainer();
    }
}
