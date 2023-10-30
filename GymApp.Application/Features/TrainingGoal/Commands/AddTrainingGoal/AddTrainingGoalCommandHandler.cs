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
        private readonly ITrainingGoalsRepository _trainingGoalsRepository;

        public AddTrainingGoalCommandHandler(ITrainingGoalsRepository trainingGoalsRepository)
        {
            _trainingGoalsRepository = trainingGoalsRepository;
        }
        public async Task<Guid> Handle(AddTrainingGoalCommand request, CancellationToken cancellationToken)
        {
            var newTrainingGoal = new Domain.Entities.TrainingGoal
            {
                Id = new Guid(),
                ProfileId = request.ProfileId,
                Content = request.TrainingGoalDTO.Content,
                Finished = request.TrainingGoalDTO.Finished,
            };
            await _trainingGoalsRepository.CreateAsync(newTrainingGoal);
            return newTrainingGoal.Id;
        }
    }
}
