using AutoMapper;
using GymApp.Application.Exceptions;
using GymApp.Application.Features.ProfilePicture;
using GymApp.Application.Interfaces.Identity;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Common;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.TrainingGoal.GetAllTrainingGoals
{
    public class GetAllTrainingGoalsQueryHandler : IRequestHandler<GetAllTrainingGoalsQuery, List<TrainingGoalDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ITrainingGoalsRepository _trainingGoals;

        public GetAllTrainingGoalsQueryHandler(IMapper mapper, ITrainingGoalsRepository trainingGoals)
        {
            _mapper = mapper;
            _trainingGoals = trainingGoals;
        }
        public async Task<List<TrainingGoalDTO>> Handle(GetAllTrainingGoalsQuery request, CancellationToken cancellationToken)
        {
            var trainingGoals = await _trainingGoals.GetTrainingGoalsByProfileId(request.ProfileId);
            var map = _mapper.Map<List<TrainingGoalDTO>>(trainingGoals);
            return map;
        }
        
     
    }
}
