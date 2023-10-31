using GymApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.Class
{
    public class ClassDTO
    {
        public Guid Id { get; set; }
        public string ClassName { get; set; }
        public int MaxUsers { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string DayOfWeek { get; set; }

    }
}
