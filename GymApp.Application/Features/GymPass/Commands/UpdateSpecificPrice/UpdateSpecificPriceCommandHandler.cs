using AutoMapper;
using GymApp.Application.Exceptions;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Enums;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.GymPass.Commands.UpdateSpecificPrice
{
    public class UpdateSpecificPriceCommandHandler : IRequestHandler<UpdateSpecificPriceCommand>
    {
        private readonly IGymPassPriceRepository _priceRepository;
        private readonly IMapper _mapper;

        public UpdateSpecificPriceCommandHandler(IGymPassPriceRepository priceRepository, IMapper mapper)
        {
            _priceRepository = priceRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateSpecificPriceCommand request, CancellationToken cancellationToken)
        {
            if (!Enum.TryParse<GymPassLength>(request.GymPassPriceDTO.Length, true, out var passLength))
                throw new BadRequestException("Invalid gym pass length");
            var pass = await _priceRepository.GetPriceById(passLength);
            pass.Price = request.GymPassPriceDTO.Price;
            await _priceRepository.UpdateAsync(pass);
            return Unit.Value;
        }
    }
}
