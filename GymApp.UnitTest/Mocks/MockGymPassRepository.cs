using AutoMapper;
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
    public class MockGymPassRepository
    {
        public static Mock<IGymPassRepository> GetGymPasses()
        {
            var passes = new List<GymPass>
            {
                new GymPass
                {
                      Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                      ProfileId =  Guid.Parse("00000000-0000-0000-0000-000000000001"),
                      StartedOn = new DateTime(2023,12,3),
                      ValidTill = new DateTime(2024,4,5)
                },
                 new GymPass
                {
                      Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                      ProfileId =  Guid.Parse("00000000-0000-0000-0000-000000000002"),
                },
                 new GymPass
                {
                      Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                      ProfileId =  Guid.Parse("00000000-0000-0000-0000-000000000003"),
                      StartedOn = new DateTime(2023,12,3),
                      ValidTill = new DateTime(2024,1,5)
                }
            };

            var mockRepository = new Mock<IGymPassRepository>();

            mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(passes);


            mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).Returns((Guid id) =>
            {
                try
                {
                    var result = passes.Where(c => c.Id == id).First();
                    return Task.FromResult(result);
                }
                catch
                {
                    GymPass result = null;
                    return Task.FromResult(result);
                }
            });

            mockRepository.Setup(r => r.CreateAsync(It.IsAny<GymPass>()))
                .Returns((GymPass c) =>
                {
                    passes.Add(c);
                    return Task.CompletedTask;
                });

            mockRepository.Setup(r => r.UpdateAsync(It.IsAny<GymPass>())).Returns((GymPass c) =>
            {
                var trainer = passes.Where(x => x.Id == c.Id).First();
                trainer = c;
                return Task.CompletedTask;
            });

            mockRepository.Setup(r => r.DeleteAsync(It.IsAny<GymPass>())).Returns((GymPass c) =>
            {
                passes.Remove(c);
                return Task.CompletedTask;
            });


            return mockRepository;

        }
    }
}
