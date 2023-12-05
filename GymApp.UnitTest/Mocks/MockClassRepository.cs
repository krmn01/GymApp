using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.UnitTests.Mock
{
    public class MockClassRepository
    {
        public static Mock<IClassRepository> GetClasses()
        {
            var classes = new List<Domain.Entities.Class>
            {
                new Domain.Entities.Class
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    ClassName = "test1",
                    MaxUsers = 10,
                    StartTime = new DateTime(2023,12,12,12,0,0),
                    EndTime = new DateTime(2023,12,12,13,0,0),
                    PersonalTrainerId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    DayOfWeek = Domain.Enums.DaysOfWeek.monday,
                    Users = new List<UsersProfile>()
                },
                new Domain.Entities.Class
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    ClassName = "test2",
                    MaxUsers = 10,
                    StartTime = new DateTime(2023,12,12,12,0,0),
                    EndTime = new DateTime(2023,12,12,13,0,0),
                    PersonalTrainerId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    DayOfWeek = Domain.Enums.DaysOfWeek.monday,
                     Users = new List<UsersProfile>
                    {
                        new UsersProfile
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        }
                    }
                },
                new Domain.Entities.Class
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    ClassName = "test3",
                    MaxUsers = 1,
                    StartTime = new DateTime(2023,12,12,12,0,0),
                    EndTime = new DateTime(2023,12,12,13,0,0),
                    PersonalTrainerId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    DayOfWeek = Domain.Enums.DaysOfWeek.monday,
                     Users = new List<UsersProfile>
                    {
                        new UsersProfile
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        }
                    }
                },
            };

            var mockRepository = new Mock<IClassRepository>();

            mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(classes);

            Guid mockedId = Guid.Parse("00000000-0000-0000-0000-000000000001");

            mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).Returns((Guid id) => 
            {
                try
                {
                    var result = classes.Where(c => c.Id == id).First();
                    return Task.FromResult(result);
                }
                catch
                {
                    Class result = null;
                    return Task.FromResult(result);
                }
            });
        
            mockRepository.Setup(r => r.GetAllUsersClasses(It.IsAny<Guid>()))
                .Returns((Guid id) =>
                {
                    List<Class> result = classes.Where(c => c.Users.Any(x => x.Id == id)).ToList();
                    return Task.FromResult(result);
                });

            mockRepository.Setup(r => r.CreateAsync(It.IsAny<Class>()))
                .Returns((Class c) =>
                {
                    classes.Add(c);
                    return Task.CompletedTask;
                });
            
            mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Class>())).Returns((Class c) =>
            {
                var @class = classes.Where(x => x.Id == c.Id).First();
                @class = c;
                return Task.CompletedTask;
            });
            
            mockRepository.Setup(r => r.DeleteAsync(It.IsAny<Class>())).Returns((Class c) =>
            {
                classes.Remove(c);
                return Task.CompletedTask;
            });


            
            return mockRepository;
        }
    }
}
