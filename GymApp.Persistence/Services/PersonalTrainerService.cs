using GymApp.Application.Features.PersonalTrainer;
using GymApp.Application.Features.PersonalTrainer.Commands.CreateNewTrainer;
using GymApp.Application.Features.PersonalTrainer.Commands.DeleteTrainer;
using GymApp.Application.Features.PersonalTrainer.Commands.UpdateTrainer;
using GymApp.Application.Features.PersonalTrainer.GetAllPersonalTrainers;
using GymApp.Application.Features.PersonalTrainer.Queries.GetPersonalTrainerById;
using GymApp.Application.Interfaces.Helpers;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Common;
using GymApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Persistence.Services
{
    public class PersonalTrainerService : IPersonalTrainerService
    {
        private readonly IMediator _mediator;
        public PersonalTrainerService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Response<List<PersonalTrainerDTO>>> GetAllTrainers()
        {
            var request = new GetAllPersonalTrainersQuery { };
            try
            {
                var response = await _mediator.Send(request);
                return new SuccessRequestResponse<List<PersonalTrainerDTO>>(data:response);
            }catch (Exception ex)
            {
                return new BadRequestResponse<List<PersonalTrainerDTO>>(ex.Message);
            }
        }

        public async Task<Response<string>> CreateNewTrainer(NewTrainerDTO newTrainer)
        {
            var request = new CreateNewTrainerCommand { NewTrainer = newTrainer };
            try 
            {
                var validator = new CreateNewTrainerCommandValidator();
                var validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                    return new BadRequestResponse<string>(ValidationHelper.ValidationErrorsToString(validationResult.Errors));

                var response = await _mediator.Send(request);
                return new SuccessRequestResponse<string>("Trainer created", response.ToString());
            }
            catch(Exception ex)
            {
                return new BadRequestResponse<string>(ex.Message);
            }
        }

        public async Task<Response<PersonalTrainerDTO>> GetPersonalTrainerById(Guid id)
        {
            var request = new GetPersonalTrainerByIdCommand { Id = id };
            try
            {
                var response = await _mediator.Send(request);
                return new SuccessRequestResponse<PersonalTrainerDTO>(data: response);
            }catch(Exception ex)
            {
                return new BadRequestResponse<PersonalTrainerDTO>(ex.Message);
            }
        }

        public async Task<Response<string>> UpdatePersonalTrainer(Guid id,UpdateTrainerDTO updateTrainer)
        {
            var request = new UpdateTrainersDataCommand { TrainerGuid = id, UpdatedTrainer = updateTrainer };
            try
            {
                var validator = new UpdateTrainersDataCommandValidator();
                var validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                    return new BadRequestResponse<string>(ValidationHelper.ValidationErrorsToString(validationResult.Errors));

                var response = await _mediator.Send(request);
                return new SuccessRequestResponse<string>("Trainer updated");
            }
            catch(Exception ex) 
            {
                return new BadRequestResponse<string>(ex.Message);
            }
        }

        public async Task<Response<string>> DeleteTrainer(Guid id)
        {
            var request = new DeleteTrainerCommand { TrainerId = id };
            try
            {
                await _mediator.Send(request);
                return new SuccessRequestResponse<string>("Trainer deleted");
            }
            catch(Exception ex)
            {
                return new BadRequestResponse<string>(ex.Message);
            }
        }
    }
}
