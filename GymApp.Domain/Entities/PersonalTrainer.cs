using GymApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Domain.Entities
{
    public class PersonalTrainer :BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [StringLength(30)]
        public string Surname { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get;set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public List<Class> Classes {get; set;} 

    }
}
