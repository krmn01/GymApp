using AutoMapper;
using GymApp.Application.Exceptions;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.GymPass.Queries.GetGymPass
{
    public class GetGymPassCommandHandler : IRequestHandler<GetGymPassCommand, GymPassDTO>
    {
        private readonly IMapper _mapper;
        private readonly IGymPassRepository _gymPassRepository;
        private readonly IUsersProfileRepository _usersProfileRepository;

        public GetGymPassCommandHandler(IMapper mapper, IGymPassRepository gymPassRepository, IUsersProfileRepository usersProfileRepository)
        {
            _mapper = mapper;
            _gymPassRepository = gymPassRepository;
            _usersProfileRepository = usersProfileRepository;
        }
        public async Task<GymPassDTO> Handle(GetGymPassCommand request, CancellationToken cancellationToken)
        {
            var user = await _usersProfileRepository.GetByIdAsync(request.ProfileId) ??
              throw new NotFoundException(new Domain.Entities.UsersProfile(), request.ProfileId.ToString());
            var gymPass = await _gymPassRepository.GetByIdAsync(user.GymPassId);
            var map = _mapper.Map<GymPassDTO>(gymPass);
            return map;
        }
    }
}
