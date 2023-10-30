using GymApp.Application.Features.TrainingGoal;
using GymApp.Application.Features.TrainingGoal.GetAllTrainingGoals;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Persistence.Services
{
    public class TrainingGoalService : ITrainingGoalService
    {
        private readonly IMediator _mediator;
        public TrainingGoalService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Response<List<TrainingGoalDTO>>> GetTrainingGoalsById(Guid id)
        {
            var request = new GetAllTrainingGoalsQuery { ProfileId = id };
            var response = await _mediator.Send(request);
            return new Response<List<TrainingGoalDTO>>
            {
                StatusCode = 200,
                Succeeded = true,
                Errors = null,
                Data = response
            };
         }
    }
}
