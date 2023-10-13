using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Domain.Common
{
    public abstract class BaseEntity
    {  
        public Guid Id { get; set; }
        public DateTime? CreatedOn { get; set;}
        public DateTime? UpdatedOn { get; set;}
    }
}
