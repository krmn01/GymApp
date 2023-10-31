using GymApp.Application.Features.TrainingGoal;
using GymApp.Application.Features.TrainingGoal.Commands.AddTrainingGoal;
using GymApp.Application.Features.TrainingGoal.Commands.DeleteTrainingGoal;
using GymApp.Application.Features.TrainingGoal.Commands.ToggleTrainingGoal;
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

        public async Task<Response<string>> AddTrainingGoal(Guid id, string content)
        {
            var request = new AddTrainingGoalCommand
            {
                ProfileId = id,
                TrainingGoalDTO = new TrainingGoalDTO
                {
                    Content = content
                }
            };
            var response = await _mediator.Send(request);

            return new Response<string>
            {
                Succeeded = true,
                StatusCode = 200,
                Data = response.ToString(),
                Errors = null
            };
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

        public async Task<Response<string>> ToggleTrainingGoal(Guid goalId,Guid profileId)
        {
            var request = new ToggleTrainingGoalCommand { ProfileId = profileId, TrainingGoalId = goalId };
            await _mediator.Send(request);
            return new Response<string>
            {
                StatusCode = 200,
                Succeeded = true,
                Errors = null,
                Message = "Training goal toggled succesfully",
                Data = string.Empty
            };
        }

        public async Task<Response<string>> DeleteTrainingGoal(Guid goalId, Guid profileId)
        {
            var request = new DeleteTrainingGoalCommand { ProfileId = profileId, TrainingGoalId = goalId };
            await _mediator.Send(request);
            return new Response<string>
            {
                StatusCode = 200,
                Succeeded = true,
                Errors = null,
                Message = "Training goal deleted succesfully",
                Data = string.Empty
            };
        }

    }
}
