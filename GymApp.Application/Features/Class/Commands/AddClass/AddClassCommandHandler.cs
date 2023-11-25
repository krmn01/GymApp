using AutoMapper;
using GymApp.Application.Exceptions;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.Class.Commands.AddClass
{
    public class AddClassCommandHandler : IRequestHandler<AddClassCommand>
    {
        private readonly IClassRepository _classRepository;
        private readonly IPersonalTrainerRepository _personalTrainerRepository;
        private readonly IMapper _mapper;

        public AddClassCommandHandler(IClassRepository classRepository, IPersonalTrainerRepository personalTrainers, IMapper mapper)
        {
            _classRepository = classRepository;
            _personalTrainerRepository = personalTrainers;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(AddClassCommand request, CancellationToken cancellationToken)
        {
            var newClass = _mapper.Map<Domain.Entities.Class>(request.ClassDTO);
            var trainer = await _personalTrainerRepository.GetByIdAsync(newClass.PersonalTrainerId) ??
                throw new NotFoundException(new Domain.Entities.PersonalTrainer(), newClass.PersonalTrainerId.ToString());

            newClass.Id = new Guid();

            await _classRepository.CreateAsync(newClass);
            trainer.Classes.Add(newClass);
            await _personalTrainerRepository.UpdateAsync(trainer);
            return Unit.Value;
        }
    }
}
