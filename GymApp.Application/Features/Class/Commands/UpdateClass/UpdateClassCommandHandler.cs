using AutoMapper;
using GymApp.Application.Exceptions;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.Class.Commands.UpdateClass
{
    public class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand>
    {
        private readonly IClassRepository _classRepository;

        public UpdateClassCommandHandler(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        public async Task<Unit> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
        {
            var @class = await _classRepository.GetByIdAsync(request.ClassId) ??
                throw new NotFoundException(new Domain.Entities.Class(), request.ClassId.ToString());
            
            @class.PersonalTrainerId = request.UpdatedClass.TrainerId ?? @class.PersonalTrainerId;
            @class.DayOfWeek =  request.UpdatedClass.DayOfWeek ?? @class.DayOfWeek;
            @class.ClassName = request.UpdatedClass.ClassName ?? @class.ClassName;
            @class.StartTime = request.UpdatedClass.StartTime ?? @class.StartTime;
            @class.EndTime = request.UpdatedClass.EndTime ?? @class.EndTime;
            @class.MaxUsers = request.UpdatedClass.MaxUsers ?? @class.MaxUsers;

            await _classRepository.UpdateAsync(@class);
            return Unit.Value;
        }
    }
}
