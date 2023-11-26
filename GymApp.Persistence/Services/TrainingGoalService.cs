using GymApp.Application.Features.TrainingGoal;
using GymApp.Application.Features.TrainingGoal.Commands.AddTrainingGoal;
using GymApp.Application.Features.TrainingGoal.Commands.DeleteTrainingGoal;
using GymApp.Application.Features.TrainingGoal.Commands.ToggleTrainingGoal;
using GymApp.Application.Features.TrainingGoal.GetAllTrainingGoals;
using GymApp.Application.Interfaces.Helpers;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.ResponseCaching;
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

            try
            {
                var validator = new AddTrainingGoalCommandValidator();
                var validationResult = validator.Validate(request);

                if(!validationResult.IsValid)
                    return new BadRequestResponse<string>(ValidationHelper.ValidationErrorsToString(validationResult.Errors));

                var response = await _mediator.Send(request);
                return new SuccessRequestResponse<string>("Training goal added",response.ToString());
            }catch(Exception ex)
            {
                return new BadRequestResponse<string>(ex.Message);
            }
        }
        public async Task<Response<List<TrainingGoalDTO>>> GetTrainingGoalsById(Guid id)
        { 
            var request = new GetAllTrainingGoalsQuery { ProfileId = id };
            try
            {
                var response = await _mediator.Send(request);
                return new SuccessRequestResponse<List<TrainingGoalDTO>>(data: response);
            }catch(Exception ex) 
            {
                return new BadRequestResponse<List<TrainingGoalDTO>>(ex.Message);
            }
         }

        public async Task<Response<string>> ToggleTrainingGoal(Guid goalId,Guid profileId)
        {
            var request = new ToggleTrainingGoalCommand { ProfileId = profileId, TrainingGoalId = goalId };
            try
            {
                await _mediator.Send(request);
                return new SuccessRequestResponse<string>("Training goal toggled succesfully");
            }catch(Exception ex)
            {
                return new BadRequestResponse<string>(ex.Message);
            }
        }

        public async Task<Response<string>> DeleteTrainingGoal(Guid goalId, Guid profileId)
        {
            var request = new DeleteTrainingGoalCommand { ProfileId = profileId, TrainingGoalId = goalId };
            try 
            {
                await _mediator.Send(request);
                return new SuccessRequestResponse<string>("Training goal deleted succesfully");
            }
            catch(Exception ex) 
            {
                return new BadRequestResponse<string>(ex.Message);
            }
        }

    }
}
