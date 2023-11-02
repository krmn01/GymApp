using AutoMapper;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.PersonalTrainer.Commands.CreateNewTrainer
{
    public class CreateNewTrainerCommandHandler : IRequestHandler<CreateNewTrainerCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IPersonalTrainerRepository _trainers;

        public CreateNewTrainerCommandHandler(IMapper mapper, IPersonalTrainerRepository trainers)
        {
            _mapper = mapper;
            _trainers = trainers;
        }
        public async Task<Guid> Handle(CreateNewTrainerCommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Domain.Entities.PersonalTrainer>(request.NewTrainer);
            map.Id = new Guid();
            map.Classes = new List<Domain.Entities.Class>();
            map.CreatedOn = DateTime.Now;
            map.UpdatedOn = DateTime.Now;
            await _trainers.CreateAsync(map);
            return map.Id;
        }
    }
}
