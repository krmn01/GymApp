using GymApp.Application.Features.PersonalTrainer;
using GymApp.Application.Features.PersonalTrainer.Commands.CreateNewTrainer;
using GymApp.Application.Features.PersonalTrainer.GetAllPersonalTrainers;
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
            var response = await _mediator.Send(request);
            return new Response<List<PersonalTrainerDTO>>
            {
                Succeeded = true,
                StatusCode = 200,
                Errors = null,
                Data = response
            };
        }

        public async Task<Response<string>> CreateNewTrainer(NewTrainerDTO newTrainer)
        {
            var request = new CreateNewTrainerCommand { NewTrainer = newTrainer };
            var response = await _mediator.Send(request);
            return new Response<string>
            {
                Succeeded = true,
                StatusCode = 200,
                Errors = null,
                Message = "Trainer created",
                Data = response.ToString()
            };
        }

        public Task<Response<PersonalTrainerDTO>> GetPersonalTrainerById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
