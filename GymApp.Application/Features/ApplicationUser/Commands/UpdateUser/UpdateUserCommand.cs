using GymApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.ApplicationUser.Commands.UpdateUser
{
    public class UpdatePictureCommand :IRequest<Unit>
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
