using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Models.Identity
{
    public class RegistrationRequest
    {
        [Required]
        [MinLength(6)]
        public string UserName { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [MinLength(8)]
        public string ConfirmPassword { get; set; }

        [Required]
        [MinLength(8)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(9)]
        [MaxLength(9)]
        public string? PhoneNumber { get; set; }
    }
}
