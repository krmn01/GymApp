using FluentValidation;
using GymApp.Application.Features.GymPass.Commands.RenewGymPass;
using GymApp.Application.Features.GymPass.Commands.UpdateSpecificPrice;
using GymApp.Application.Features.GymPass.Queries.GetGymPass;
using GymApp.Application.Features.GymPass.Queries.GetGymPassPrices;
using GymApp.Application.Interfaces.Helpers;
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
            try
            {
                var response = await _mediator.Send(request);
                response.QrCode = _qrService.GenerateGymPassQrCode(response.Id, response.ValidTill, response.StartedOn);
                return new SuccessRequestResponse<GymPassDTO>(data:response);
            }catch (Exception ex)
            {
                return new BadRequestResponse<GymPassDTO>(ex.Message);
            }
        }

        public async Task<Response<List<GymPassPriceDTO>>> GetPricesAsync()
        {
            var request = new GetGymPassPricesQuery();
            try
            {
                var response = await _mediator.Send(request);
                return new SuccessRequestResponse<List<GymPassPriceDTO>>(data:response);
            }catch(Exception ex) 
            {
                return new BadRequestResponse<List<GymPassPriceDTO>>(ex.Message);
            }
        }

        public async Task<Response<string>> RenewAsync(Guid profileId, int days)
        {
            var request = new RenewGymPassCommand { NumberOfDays = days, ProfileId = profileId };
            try
            {
                var validator = new RenewGymPassCommandValidator();
                var validationResult = validator.Validate(request);

                if (!validationResult.IsValid) 
                    return new BadRequestResponse<string>(ValidationHelper.ValidationErrorsToString(validationResult.Errors));

                await _mediator.Send(request);
                return new SuccessRequestResponse<string>("Gym pass renewed");
            }catch(Exception ex)
            {
                return new BadRequestResponse<string>(ex.Message);
            }
        }

        public async Task<Response<string>> UpdatePriceAsync(GymPassPriceDTO price)
        {
            var request = new UpdateSpecificPriceCommand { GymPassPriceDTO = price };
            try
            {
                var validator = new UpdateSpecificPriceCommandValidator();
                var validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                    return new BadRequestResponse<string>(ValidationHelper.ValidationErrorsToString(validationResult.Errors));

                await _mediator.Send(request);
                return new SuccessRequestResponse<string>("Price updated");
            }catch(Exception ex)
            {
                return new BadRequestResponse<string>(ex.Message);
            }
        }
    }
}
