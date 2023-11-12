using GymApp.Application.Features.GymEntry.Commands.AddGymEntry;
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
    public class GymEntryService : IGymEntryService
    {
        private IMediator _mediator;

        public GymEntryService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Response<string>> AddGymEntry(Guid profileId, int timeInMinutes)
        {
           var request = new AddGymEntryCommand { profileId = profileId, timeInMinutes = timeInMinutes };
           var response = await _mediator.Send(request);
            return new Response<string>
            {
                StatusCode = 200,
                Succeeded = true,
                Message = "Gym entry added",
                Data = response.ToString()
            };
        }
    }
}
