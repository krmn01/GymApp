using GymApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.ProfilePicture.Queries.GetPicture
{
    public class GetPictureQuery :IRequest<ProfilePictureDTO>
    {
        public Guid Id { get; set; }
    }
}
