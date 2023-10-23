using AutoMapper;
using GymApp.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.ProfilePicture.Commands.UpdatePicture
{
    public class UpdatePictureCommandHandler : IRequestHandler<UpdatePictureCommand,Guid>
    {
        private readonly IProfilePictureRepository _profilePictureRepository;
        private readonly IMapper _mapper;
        public UpdatePictureCommandHandler(IProfilePictureRepository pictureRepository, IMapper mapper)
        {
            _mapper = mapper;
            _profilePictureRepository = pictureRepository;
        }

        public async Task<Guid> Handle(UpdatePictureCommand request, CancellationToken cancellationToken)
        {
            var updatedPicture = await _profilePictureRepository.GetByIdAsync(request.Id);
            updatedPicture.Picture = request.Content;
            if (updatedPicture.Id == Guid.Parse("00000000-0000-0000-0000-000000000001"))
            {
                updatedPicture.Id = new Guid();
                await _profilePictureRepository.CreateAsync(updatedPicture);
                return updatedPicture.Id;
            }
            await _profilePictureRepository.UpdateAsync(updatedPicture);
            return updatedPicture.Id;
        }
    }
}
