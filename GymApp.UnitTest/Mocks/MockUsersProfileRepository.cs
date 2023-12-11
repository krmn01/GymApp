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
    public class MockUsersProfileRepository
    {
            public static Mock<IUsersProfileRepository> GetProfiles()
            {
               var profiles = new List<UsersProfile>
                {
                   new UsersProfile
                   {
                       Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                       Classes = new List<Class>(),
                       GymPassId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                       ProfilePictureId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                       TrainingGoals = new List<TrainingGoal>()
                   },
                   new UsersProfile
                   {
                       Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                       Classes = new List<Class>(),
                       GymPassId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                       TrainingGoals = new List<TrainingGoal>()
                   },
                   new UsersProfile
                   {
                       Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                       Classes = new List<Class>(),
                       GymPassId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                       TrainingGoals = new List<TrainingGoal>()
                   }
                };

               var mockRepository = new Mock<IUsersProfileRepository>();

               mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(profiles);


                mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).Returns((Guid id) =>
                {
                    try
                    {
                        var result = profiles.Where(c => c.Id == id).First();
                        return Task.FromResult(result);
                    }
                    catch
                    {
                        UsersProfile result = null;
                        return Task.FromResult(result);
                    }
                });

                mockRepository.Setup(r => r.CreateAsync(It.IsAny<UsersProfile>()))
                    .Returns((UsersProfile c) =>
                    {
                        profiles.Add(c);
                        return Task.CompletedTask;
                    });

                mockRepository.Setup(r => r.UpdateAsync(It.IsAny<UsersProfile>())).Returns((UsersProfile c) =>
                {
                    var trainer = profiles.Where(x => x.Id == c.Id).First();
                    trainer = c;
                    return Task.CompletedTask;
                });

                mockRepository.Setup(r => r.DeleteAsync(It.IsAny<UsersProfile>())).Returns((UsersProfile c) =>
                {
                    profiles.Remove(c);
                    return Task.CompletedTask;
                });


                return mockRepository;
            }
        }
    }


