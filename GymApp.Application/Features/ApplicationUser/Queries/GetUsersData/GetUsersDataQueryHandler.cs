﻿using AutoMapper;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.ApplicationUser.Queries.GetUsersData
{
    public class GetUsersDataQueryHandler : IRequestHandler<GetUsersDataQuery, ApplicationUserDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUsersDataQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<ApplicationUserDTO> Handle(GetUsersDataQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.id);
            return _mapper.Map<ApplicationUserDTO>(user);
        }
    }
}