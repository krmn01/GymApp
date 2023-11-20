using GymApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.GymPass.Queries.GetGymPassPrices
{
    public class GetGymPassPricesQuery :IRequest<List<GymPassPriceDTO>>
    {
    }
}
