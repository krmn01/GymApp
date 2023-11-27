using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.Class.Commands.UpdateClass
{
    public class UpdateClassCommand :IRequest<Unit>
    {
        public Guid ClassId { get; set; }
        public UpdateClassDTO UpdatedClass { get; set; }   
    }
}
