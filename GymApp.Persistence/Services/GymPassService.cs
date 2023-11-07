using GymApp.Application.Features.GymPass.Commands.RenewGymPass;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Persistence.Services
{
    public class GymPassService : IGymPassService
    {
        private readonly IMediator _mediator;

        public GymPassService(IMediator mediator)
        {
            _mediator = mediator;  
        }
        public async Task<Response<string>> RenewAsync(Guid profileId, int days)
        {
            var request = new RenewGymPassCommand { NumberOfDays = days, ProfileId = profileId };
            await _mediator.Send(request);
            return new Response<string>
            {
                StatusCode = 200,
                Succeeded = true,
                Message = "Gym pass renewed"
            };
        }
    }
}
