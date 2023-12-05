using AutoMapper;
using GymApp.Application.Exceptions;
using GymApp.Application.Features.TrainingGoal.Commands.ToggleTrainingGoal;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.TrainingGoal.Commands.DeleteTrainingGoal
{
    public class DeleteTrainingGoalCommandHandler : IRequestHandler<DeleteTrainingGoalCommand, Unit>
    {
        private readonly ITrainingGoalsRepository _trainingGoalsRepository;

        public DeleteTrainingGoalCommandHandler(ITrainingGoalsRepository trainingGoalsRepository)
        {
            _trainingGoalsRepository = trainingGoalsRepository;
        }
        public async Task<Unit> Handle(DeleteTrainingGoalCommand request, CancellationToken cancellationToken)
        {
            var goal = await _trainingGoalsRepository.GetByIdAsync(request.TrainingGoalId) ??
                throw new NotFoundException(new Domain.Entities.TrainingGoal(), request.TrainingGoalId.ToString());
            if (goal.ProfileId != request.ProfileId) throw new BadRequestException("You're not authorized to delete this goal", new FluentValidation.Results.ValidationResult());
            await _trainingGoalsRepository.DeleteAsync(goal);
            return Unit.Value;
        }
    }
}
