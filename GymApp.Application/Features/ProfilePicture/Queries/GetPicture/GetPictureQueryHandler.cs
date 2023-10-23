using AutoMapper;
using GymApp.Application.Exceptions;
using GymApp.Application.Features.ApplicationUser.Queries.GetUsersData;
using GymApp.Application.Interfaces.Identity;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Common;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.ProfilePicture.Queries.GetPicture
{
    public class GetPictureQueryHandler : IRequestHandler<GetPictureQuery, ProfilePictureDTO>
    {
        private readonly IMapper _mapper;
        private readonly IProfilePictureRepository _profilePictureRepository;

        public GetPictureQueryHandler(IMapper mapper, IProfilePictureRepository profilePictureRepository)
        {
            _mapper = mapper;
            _profilePictureRepository = profilePictureRepository;
        }
        public async Task<ProfilePictureDTO> Handle(GetPictureQuery request, CancellationToken cancellationToken)
        {
            var picture = await _profilePictureRepository.GetByIdAsync(request.Id) ??
                throw new NotFoundException(request.Id, typeof(Domain.Entities.ProfilePicture).ToString());
            var map = _mapper.Map<ProfilePictureDTO>(picture);
            return new ProfilePictureDTO
            {
                Id = request.Id,
                Content = Convert.ToBase64String(picture.Picture),
                CreatedOn = picture.CreatedOn,
                UpdatedOn = picture.UpdatedOn
            };
        }
    }
}
