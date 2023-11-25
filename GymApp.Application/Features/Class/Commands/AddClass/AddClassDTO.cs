using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.Class.Commands.AddClass
{
    public class AddClassDTO
    {
        public string ClassName { get; set; }
        public int MaxUsers { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string DayOfWeek { get; set; }
        public Guid TrainerId { get; set; }
    }
}
