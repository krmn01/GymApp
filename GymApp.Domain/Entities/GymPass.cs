using GymApp.Domain.Common;
using GymApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Domain.Entities
{
    public class GymPass :BaseEntity
    {
        [ForeignKey("ProfileId")]
        public Guid ProfileId { get; set; }
        public UsersProfile Profile {  get; set; }
        public DateTime? ValidTill { get; set; }
        public DateTime? StartedOn { get; set; }
    }
}
