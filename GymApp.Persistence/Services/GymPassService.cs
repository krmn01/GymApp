using GymApp.Application.Features.GymPass.Commands.RenewGymPass;
using GymApp.Application.Features.GymPass.Queries.GetGymPass;
using GymApp.Application.Features.GymPass.Queries.GetGymPassPrices;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Common;
using GymApp.Domain.Entities;
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
        private readonly IQrService _qrService;

        public GymPassService(IMediator mediator, IQrService qrService)
        {
            _mediator = mediator;  
            _qrService = qrService;
        }

        public async Task<Response<GymPassDTO>> GetAsync(Guid profileId)
        {
            var request = new GetGymPassCommand { ProfileId = profileId };
            var response = await _mediator.Send(request);
            response.QrCode = _qrService.GenerateGymPassQrCode(response.Id, response.ValidTill, response.StartedOn);
            
            return new Response<GymPassDTO>
            {
                StatusCode = 200,
                Succeeded = true,
                Data = response
            };
        }

        public async Task<Response<List<GymPassPriceDTO>>> GetPricesAsync()
        {
            var request = new GetGymPassPricesQuery();
            var response = await _mediator.Send(request);
            return new Response<List<GymPassPriceDTO>>
            {
                StatusCode = 200,
                Succeeded = true,
                Data = response
            };
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
