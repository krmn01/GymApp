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
    public class AssignUserToClassCommandHandler : IRequestHandler<AssignUserToClassCommand, Unit>
    {
        private readonly IClassRepository _classRepository;
        private readonly IUsersProfileRepository _usersProfileRepository;

        public AssignUserToClassCommandHandler(IClassRepository classRepository, IUsersProfileRepository usersProfileRepository)
        {
            _classRepository = classRepository;
            _usersProfileRepository = usersProfileRepository;
        }
        public async Task<Unit> Handle(AssignUserToClassCommand request, CancellationToken cancellationToken)
        {
            var targetClass = await _classRepository.GetByIdAsync(request.ClassId);
            if(targetClass == null) throw new NotFoundException(new Domain.Entities.Class(),request.ClassId.ToString());
           
            var user = await _usersProfileRepository.GetByIdAsync(request.UserProfileId);
            if (user == null) throw new NotFoundException(new Domain.Entities.UsersProfile(), request.UserProfileId.ToString());

            if (targetClass.Users == null) targetClass.Users = new List<Domain.Entities.UsersProfile>();
           // if (user.Classes == null) user.Classes = new List<Domain.Entities.Class>();

            targetClass.Users.Add(user);
            //user.Classes.Append(targetClass);
            
            await _classRepository.UpdateAsync(targetClass);
            //await _usersProfileRepository.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
