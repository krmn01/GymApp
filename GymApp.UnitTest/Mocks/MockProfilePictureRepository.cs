using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.UnitTests.Mocks
{
    public class MockProfilePictureRepository
    {
        public static Mock<IProfilePictureRepository> GetPictures()
        {
            var pictures = new List<ProfilePicture>
                {
                   new ProfilePicture
                   {
                       Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                       Picture = new byte[] {1, 2, 3,}
                   },
                    new ProfilePicture
                   {
                       Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                       Picture = new byte[] {3, 2, 1,}
                   },
                };

            var mockRepository = new Mock<IProfilePictureRepository>();

            mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(pictures);


            mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).Returns((Guid id) =>
            {
                try
                {
                    var result = pictures.Where(c => c.Id == id).First();
                    return Task.FromResult(result);
                }
                catch
                {
                    ProfilePicture result = null;
                    return Task.FromResult(result);
                }
            });

            mockRepository.Setup(r => r.CreateAsync(It.IsAny<ProfilePicture>()))
                .Returns((ProfilePicture c) =>
                {
                    pictures.Add(c);
                    return Task.CompletedTask;
                });

            mockRepository.Setup(r => r.UpdateAsync(It.IsAny<ProfilePicture>())).Returns((ProfilePicture c) =>
            {
                var trainer = pictures.Where(x => x.Id == c.Id).First();
                trainer = c;
                return Task.CompletedTask;
            });

            mockRepository.Setup(r => r.DeleteAsync(It.IsAny<ProfilePicture>())).Returns((ProfilePicture c) =>
            {
                pictures.Remove(c);
                return Task.CompletedTask;
            });


            return mockRepository;
        }
    }
}
