using AutoMapper;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.GymPass.Queries.GetGymPassPrices
{
    public class GetGymPassPricesQueryHandler : IRequestHandler<GetGymPassPricesQuery, List<GymPassPriceDTO>>
    {
        private readonly IGymPassPriceRepository _priceRepository;
        private readonly IMapper _mapper;

        public GetGymPassPricesQueryHandler(IGymPassPriceRepository priceRepository, IMapper mapper)
        {
            _priceRepository = priceRepository;
            _mapper = mapper;
        }
        public async Task<List<GymPassPriceDTO>> Handle(GetGymPassPricesQuery request, CancellationToken cancellationToken)
        {
            var prices = await _priceRepository.GetAllAsync();
            return _mapper.Map<List<GymPassPriceDTO>>(prices);
        }
    }
}
