using AutoMapper;
using GymApp.Application.Exceptions;
using GymApp.Application.Features.TrainingGoal.Commands.AddTrainingGoal;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.TrainingGoal.Commands.ToggleTrainingGoal
{
    public class ToggleTrainingGoalCommandHandler : IRequestHandler<ToggleTrainingGoalCommand,Unit>
    {
        private readonly ITrainingGoalsRepository _trainingGoalsRepository;

        public ToggleTrainingGoalCommandHandler(ITrainingGoalsRepository trainingGoalsRepository)
        {
            _trainingGoalsRepository = trainingGoalsRepository;
        }
        public async Task<Unit> Handle(ToggleTrainingGoalCommand request, CancellationToken cancellationToken)
        {
            var goal = await _trainingGoalsRepository.GetByIdAsync(request.TrainingGoalId) ??
                throw new NotFoundException(new Domain.Entities.TrainingGoal(),request.TrainingGoalId.ToString());
            if (goal.ProfileId != request.ProfileId) throw new BadRequestException("You're not authorized to update this goal", new FluentValidation.Results.ValidationResult());

            goal.Finished = !goal.Finished;
            await _trainingGoalsRepository.UpdateAsync(goal);
            return Unit.Value;
        }
    }
}
