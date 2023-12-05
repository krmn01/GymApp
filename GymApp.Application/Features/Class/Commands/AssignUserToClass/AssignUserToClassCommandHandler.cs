using GymApp.Application.Exceptions;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.Class.Commands
{
    public class UnassignUserFromClassCommandHandler : IRequestHandler<UnassignUserFromClassCommand, Unit>
    {
        private readonly IClassRepository _classRepository;
        private readonly IUsersProfileRepository _usersProfileRepository;

        public UnassignUserFromClassCommandHandler(IClassRepository classRepository, IUsersProfileRepository usersProfileRepository)
        {
            _classRepository = classRepository;
            _usersProfileRepository = usersProfileRepository;
        }
        public async Task<Unit> Handle(UnassignUserFromClassCommand request, CancellationToken cancellationToken)
        {
            var targetClass = await _classRepository.GetByIdAsync(request.ClassId) ??
            throw new NotFoundException(new Domain.Entities.Class(),request.ClassId.ToString());
           
            var user = await _usersProfileRepository.GetByIdAsync(request.UserProfileId) ??
            throw new NotFoundException(new Domain.Entities.UsersProfile(), request.UserProfileId.ToString());

            if (targetClass.Users == null) targetClass.Users = new List<Domain.Entities.UsersProfile>();

            if (targetClass.Users.Count >= targetClass.MaxUsers) throw new BadRequestException("Class already has reached maximum users count");   
            if (targetClass.Users.Any(x => x.Id == request.UserProfileId)) throw new BadRequestException("User already assigned");
            targetClass.Users.Add(user);
            await _classRepository.UpdateAsync(targetClass);

            return Unit.Value;
        }
    }
}
