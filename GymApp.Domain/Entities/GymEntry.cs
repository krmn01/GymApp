using GymApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Domain.Entities
{
    public class GymEntry :BaseEntity
    {
        [ForeignKey("GymPassId")]
        public Guid GymPassId { get; set; }
        public GymPass Pass { get; set; }
        public DateTime? EnteredOn { get; set; }
        public DateTime? ExitedOn { get; set; }
    }
}
