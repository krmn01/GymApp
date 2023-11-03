using AutoMapper;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.Class.Queries.GetUsersClasses
{
    public class GetUsersClassesQueryHandler : IRequestHandler<GetUsersClassesQuery, List<ClassDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IClassRepository _classes;

        public GetUsersClassesQueryHandler(IMapper mapper, IClassRepository classes)
        {
            _mapper = mapper;
            _classes = classes;
        }
        public async Task<List<ClassDTO>> Handle(GetUsersClassesQuery request, CancellationToken cancellationToken)
        {
            var classes = await _classes.GetAllUsersClasses(request.ProfileId);
            var map = _mapper.Map<List<ClassDTO>>(classes);
            return map;
        }
    }
}
