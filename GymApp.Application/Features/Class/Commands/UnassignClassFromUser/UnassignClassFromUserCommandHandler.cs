using GymApp.Application.Exceptions;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.Class.Commands.UnassignClassFromUser
{
    public class UnassignClassFromUserCommandHandler : IRequestHandler<UnassignClassFromUserCommand, Unit>
    {
        private readonly IClassRepository _classRepository;
        private readonly IUsersProfileRepository _usersProfileRepository;

        public UnassignClassFromUserCommandHandler(IClassRepository classRepository, IUsersProfileRepository usersProfileRepository)
        {
            _classRepository = classRepository;
            _usersProfileRepository = usersProfileRepository;
        }
        public async Task<Unit> Handle(UnassignClassFromUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _usersProfileRepository.GetByIdAsync(request.ProfileId)
                ?? throw new NotFoundException(new Domain.Entities.UsersProfile(), request.ProfileId.ToString());
            var @class = await _classRepository.GetByIdAsync(request.ClassId) 
                ?? throw new NotFoundException(new Domain.Entities.Class(), request.ClassId.ToString());

            if (@class.Users.Contains(user)) @class.Users.Remove(user);

            await _classRepository.UpdateAsync(@class);
            return Unit.Value;
        }
    }
}
