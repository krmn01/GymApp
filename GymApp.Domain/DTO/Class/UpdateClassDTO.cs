using GymApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.Class.Commands.UpdateClass
{
    public class UpdateClassDTO
    {
        public string? ClassName { get; set; } = null;
        public int? MaxUsers { get; set; } = null;
        public DateTime? StartTime { get; set; } = null;
        public DateTime? EndTime { get; set; } = null;
        public DaysOfWeek? DayOfWeek { get; set; } = null;
        public Guid? TrainerId { get; set; } = null;
    }
}
