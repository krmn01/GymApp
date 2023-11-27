using GymApp.Application.Exceptions;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.Class.Commands.DeleteClass
{
    public class DeleteClassCommandHandler : IRequestHandler<DeleteClassCommand>
    {
        private readonly IClassRepository _classRepository;

        public DeleteClassCommandHandler(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        public async Task<Unit> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
        {
            var @class = await _classRepository.GetByIdAsync(request.ClassId) ??
                throw new NotFoundException(new Domain.Entities.Class(), request.ClassId.ToString());
            await _classRepository.DeleteAsync(@class);
            return Unit.Value;
        }
    }
}
