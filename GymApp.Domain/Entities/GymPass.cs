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
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public UsersProfile User {  get; set; }
        public DateTime? ValidTill { get; set; }
        public DateTime? StartedOn { get; set; }
        public GymPassTypes PassType { get; set; }
    }
}
