using AutoMapper;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.TrainingGoal.Commands.AddTrainingGoal
{
    public class AddTrainingGoalCommandHandler : IRequestHandler<AddTrainingGoalCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ITrainingGoalsRepository _trainingGoalsRepository;

        public AddTrainingGoalCommandHandler(IMapper mapper, ITrainingGoalsRepository trainingGoalsRepository)
        {
            _mapper = mapper;
            _trainingGoalsRepository = trainingGoalsRepository;
        }
        public async Task<Guid> Handle(AddTrainingGoalCommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Domain.Entities.TrainingGoal>(request.TrainingGoalDTO);
            map.Id = new Guid();
            map.ProfileId = request.ProfileId;
            map.Finished = false;
            await _trainingGoalsRepository.CreateAsync(map);
            return map.Id;
        }
    }
}
