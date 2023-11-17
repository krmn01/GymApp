using GymApp.Application.Exceptions;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.PersonalTrainer.Commands.DeleteTrainer
{
    public class DeleteTrainerCommandHandler : IRequestHandler<DeleteTrainerCommand>
    {
        private readonly IPersonalTrainerRepository _personalTrainerRepository;

        public DeleteTrainerCommandHandler(IPersonalTrainerRepository personalTrainerRepository)
        {
            _personalTrainerRepository = personalTrainerRepository;
        }
        public async Task<Unit> Handle(DeleteTrainerCommand request, CancellationToken cancellationToken)
        {
            var trainer = await _personalTrainerRepository.GetByIdAsync(request.TrainerId) ??
                          throw new NotFoundException(new Domain.Entities.PersonalTrainer(), request.TrainerId.ToString());
            await _personalTrainerRepository.DeleteAsync(trainer);
            return Unit.Value;
        }
    }
}
