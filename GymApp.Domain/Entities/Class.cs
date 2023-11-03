using GymApp.Domain.Common;
using GymApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Domain.Entities
{
    public class Class :BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string ClassName { get; set; }
        public List<UsersProfile> Users { get; set; }

        [ForeignKey("PersonalTrainerId")]
        public Guid PersonalTrainerId { get; set; }
        public PersonalTrainer PersonalTrainer { get; set; }
        public int MaxUsers { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DaysOfWeek DayOfWeek { get; set; }

    }
}
