using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.ApplicationUser.Commands.DeleteUser
{
    public class DeleteUserCommand :IRequest<Unit>
    {
        public Guid id { get; set; }
    }
}
