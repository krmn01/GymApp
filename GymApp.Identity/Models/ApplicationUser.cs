using GymApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Identity.Models
{
    public class ApplicationUser :IdentityUser
    {
        [Required]
        [StringLength(40)]
        public string FullName { get; set; } = string.Empty;

        [MinLength(9)]
        [StringLength(9)]
        public override string? PhoneNumber { get; set; } = string.Empty;

        [Required]
        public Guid ProfilePictureId { get; set; } = Guid.Parse("00000000-0000-0000-0000-000000000001");

    }
}
