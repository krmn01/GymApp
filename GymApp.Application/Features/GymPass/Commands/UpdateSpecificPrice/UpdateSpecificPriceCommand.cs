using GymApp.Application.Features.GymPass.Queries.GetGymPassPrices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.GymPass.Commands.UpdateSpecificPrice
{
    public class UpdateSpecificPriceCommand :IRequest<Unit>
    {
        public GymPassPriceDTO GymPassPriceDTO { get; set; }
    }
}
