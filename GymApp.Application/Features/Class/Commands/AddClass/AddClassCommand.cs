using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.Class.Commands.AddClass
{
    public class AddClassCommand :IRequest<Unit>
    {
        public AddClassDTO ClassDTO { get; set; }
    }
}
