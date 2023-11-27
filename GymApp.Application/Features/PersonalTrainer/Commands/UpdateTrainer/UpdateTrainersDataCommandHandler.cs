using AutoMapper;
using GymApp.Application.Exceptions;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.PersonalTrainer.Commands.UpdateTrainer
{
    public class UpdateTrainersDataCommandHandler : IRequestHandler<UpdateTrainersDataCommand, Unit>
    {
        private readonly IPersonalTrainerRepository _trainers;
        public UpdateTrainersDataCommandHandler(IPersonalTrainerRepository trainers)
        {
            _trainers = trainers;
        }
        public async Task<Unit> Handle(UpdateTrainersDataCommand request, CancellationToken cancellationToken)
        {
            var trainer = await _trainers.GetByIdAsync(request.TrainerGuid) ??
                 throw new NotFoundException(new Domain.Entities.PersonalTrainer(), request.TrainerGuid.ToString());

            trainer.Name = request.UpdatedTrainer.Name != null ? request.UpdatedTrainer.Name : trainer.Name;
            trainer.Surname = request.UpdatedTrainer.Surname != null ? request.UpdatedTrainer.Surname : trainer.Surname;
            trainer.PhoneNumber = request.UpdatedTrainer.PhoneNumber != null ? request.UpdatedTrainer.PhoneNumber : trainer.PhoneNumber;
            trainer.Email = request.UpdatedTrainer.Email != null ? request.UpdatedTrainer.Email : trainer.Email;
            
            await _trainers.UpdateAsync(trainer);
            return Unit.Value;
        }
    }
}
