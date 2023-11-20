using GymApp.Domain.Common;
using GymApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Domain.Entities
{
    public class GymPassPrice
    {
        public GymPassLength Length { get; set; }
        public decimal Price { get; set; }
    }
}
