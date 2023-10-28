using GymApp.Application.Features.ProfilePicture;
using GymApp.Application.Models.Identity;
using GymApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.UsersProfile.Commands.CreateUsersProfile
{
    public class CreateUsersProfileCommand :IRequest<Guid>
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public Guid ProfilePictureId { get; set; }
    }
}
