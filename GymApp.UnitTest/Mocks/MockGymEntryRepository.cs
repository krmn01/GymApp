using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Entities;
using GymApp.Domain.Enums;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.UnitTests.Mocks
{
    public class MockGymEntryRepository
    {
        public static Mock<IGymEntryRepository> GetGymEntries()
        {
            var entries = new List<GymEntry>
            {
               new GymEntry
               {
                   Id =Guid.Parse("00000000-0000-0000-0000-000000000001"),
                   GymPassId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                   EnteredOn = new DateTime(2023,12,03,16,30,20),
                   ExitedOn = new DateTime(2023,12,03,17,30,20)    
               },
               new GymEntry
               {
                   Id =Guid.Parse("00000000-0000-0000-0000-000000000002"),
                   GymPassId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                   EnteredOn = new DateTime(2023,12,04,16,30,20),
                   ExitedOn = new DateTime(2023,12,04,17,30,20)
               },
              new GymEntry
               {
                   Id =Guid.Parse("00000000-0000-0000-0000-000000000003"),
                   GymPassId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                   EnteredOn = new DateTime(2023,12,05,16,30,20),
                   ExitedOn = new DateTime(2023,12,05,17,30,20)
               },
            };

            var mockRepository = new Mock<IGymEntryRepository>();

            mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(entries);

            mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).Returns((Guid id) =>
            {
                try
                {
                    var result = entries.Where(c => c.Id == id).First();
                    return Task.FromResult(result);
                }
                catch
                {
                    GymEntry result = null;
                    return Task.FromResult(result);
                }
            });

            mockRepository.Setup(r => r.CreateAsync(It.IsAny<GymEntry>()))
                .Returns((GymEntry c) =>
                {
                    entries.Add(c);
                    return Task.CompletedTask;
                });

            mockRepository.Setup(r => r.UpdateAsync(It.IsAny<GymEntry>())).Returns((GymEntry c) =>
            {
                var entry = entries.Where(x => x.Id == c.Id).First();
                entry = c;
                return Task.CompletedTask;
            });

            mockRepository.Setup(r => r.DeleteAsync(It.IsAny<GymEntry>())).Returns((GymEntry c) =>
            {
                entries.Remove(c);
                return Task.CompletedTask;
            });


            return mockRepository;

        }
    }
}

