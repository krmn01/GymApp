﻿using AutoMapper;
using GymApp.Application.Exceptions;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.PersonalTrainer.Queries.GetPersonalTrainerById
{
    public class GetPersonalTrainerByIdQueryHandler : IRequestHandler<GetPersonalTrainerByIdQuery, PersonalTrainerDTO>
    {
        private readonly IPersonalTrainerRepository _personalTrainerRepository;
        private readonly IMapper _mapper;
        public GetPersonalTrainerByIdQueryHandler(IPersonalTrainerRepository personalTrainerRepository, IMapper mapper)
        {
            _personalTrainerRepository = personalTrainerRepository;
            _mapper = mapper;
        }
        public async Task<PersonalTrainerDTO> Handle(GetPersonalTrainerByIdQuery request, CancellationToken cancellationToken)
        {
            var trainer = await _personalTrainerRepository.GetByIdAsync(request.Id) ??
                throw new NotFoundException(new Domain.Entities.PersonalTrainer(), request.Id.ToString());
            return _mapper.Map<PersonalTrainerDTO>(trainer);
        }
    }
}
