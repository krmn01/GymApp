using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.Class.Commands.UnassignClassFromUser
{
    public class UnassignClassFromUserCommand :IRequest<Unit>
    {
        public Guid ProfileId { get; set;}
        public Guid ClassId { get; set;}
    }
}
