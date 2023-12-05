using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.GymPass.Queries.GetGymPass
{
    public class GetGymPassQuery :IRequest<GymPassDTO>
    {
        public Guid ProfileId { get; set; }
    }
}
