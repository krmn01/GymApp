using AutoMapper;
using GymApp.Application.Exceptions;
using GymApp.Application.Features.PersonalTrainer.GetAllPersonalTrainers;
using GymApp.Application.Features.ProfilePicture;
using GymApp.Application.Interfaces.Identity;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Common;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.PersonalTrainer.GetAllPersonalTrainers
{
    public class GetAllPersonalTrainersQueryHandler : IRequestHandler<GetAllPersonalTrainersQuery, List<PersonalTrainerDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IPersonalTrainerRepository _trainers;

        public GetAllPersonalTrainersQueryHandler(IMapper mapper, IPersonalTrainerRepository trainers)
        {
            _mapper = mapper;
            _trainers = trainers;
        }
        public async Task<List<PersonalTrainerDTO>> Handle(GetAllPersonalTrainersQuery request, CancellationToken cancellationToken)
        {
            var trainers = await _trainers.GetAllAsync();
            var map = _mapper.Map<List<PersonalTrainerDTO>>(trainers);
            return map;
        }
        
     
    }
}
