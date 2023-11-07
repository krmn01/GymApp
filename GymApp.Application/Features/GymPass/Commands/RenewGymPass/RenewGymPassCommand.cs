using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.GymPass.Commands.RenewGymPass
{
    public class RenewGymPassCommand :IRequest<Guid>
    {
        public Guid ProfileId { get; set; }
        public int NumberOfDays { get; set; }
    }
}
