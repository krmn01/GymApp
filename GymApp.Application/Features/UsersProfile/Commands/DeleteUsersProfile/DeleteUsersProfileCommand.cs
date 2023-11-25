using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.UsersProfile.Commands.DeleteUsersProfile
{
    public class DeleteUsersProfileCommand :IRequest<Unit>
    {
        public Guid ProfileId { get; set; }
    }
}
