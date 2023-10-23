using GymApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.ProfilePicture.Commands.UpdatePicture
{
    public class UpdatePictureCommand :IRequest<Guid>
    {
        [Required]
        public byte[] Content { get; set; }

        [Required]
        public Guid Id { get; set; }

    }
}
