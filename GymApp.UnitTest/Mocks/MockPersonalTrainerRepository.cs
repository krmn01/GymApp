using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.UnitTests.Mock
{
    public class MockPersonalTrainerRepository
    {
        public static Mock<IPersonalTrainerRepository> GetTrainers()
        {
            var trainers = new List<PersonalTrainer>
            {
                new PersonalTrainer
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Name = "Name",
                    Surname = "Surname",
                    Classes = new List<Class>
                    {
                        new Class
                        {
                              Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                              ClassName = "test1",
                              MaxUsers = 10,
                              StartTime = new DateTime(2023,12,12,12,0,0),
                              EndTime = new DateTime(2023,12,12,13,0,0),
                              PersonalTrainerId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                              DayOfWeek = Domain.Enums.DaysOfWeek.monday
                        }
                    },
                    Email = "test1@t.com",
                    PhoneNumber = "123456789"
                },
                new PersonalTrainer
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Name = "Namee",
                    Surname = "Surnamee",
                    Classes = new List<Class>
                    {
                        new Class
                        {
                              Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                              ClassName = "test2",
                              MaxUsers = 10,
                              StartTime = new DateTime(2023,12,12,12,0,0),
                              EndTime = new DateTime(2023,12,12,13,0,0),
                              PersonalTrainerId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                              DayOfWeek = Domain.Enums.DaysOfWeek.monday
                        }
                    },
                    Email = "test2@t.com",
                    PhoneNumber = "987654321"
                },
                new PersonalTrainer
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Name = "Nameee",
                    Surname = "Surnameee",
                    Classes = new List<Class>
                    {
                        new Class
                        {
                              Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                              ClassName = "test3",
                              MaxUsers = 10,
                              StartTime = new DateTime(2023,12,12,12,0,0),
                              EndTime = new DateTime(2023,12,12,13,0,0),
                              PersonalTrainerId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                              DayOfWeek = Domain.Enums.DaysOfWeek.monday
                        }
                    },
                    Email = "test2@t.com",
                    PhoneNumber = "123321123"
                }
            };

            var mockRepository = new Mock<IPersonalTrainerRepository>();

            mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(trainers);


            mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).Returns((Guid id) =>
            {
                try
                {
                    var result = trainers.Where(c => c.Id == id).First();
                    return Task.FromResult(result);
                }
                catch
                {
                    PersonalTrainer result = null;
                    return Task.FromResult(result);
                }
            });

            mockRepository.Setup(r => r.CreateAsync(It.IsAny<PersonalTrainer>()))
                .Returns((PersonalTrainer c) =>
                {
                    trainers.Add(c);
                    return Task.CompletedTask;
                });

            mockRepository.Setup(r => r.UpdateAsync(It.IsAny<PersonalTrainer>())).Returns((PersonalTrainer c) =>
            {
                var trainer = trainers.Where(x => x.Id == c.Id).First();
                trainer = c;
                return Task.CompletedTask;
            });

            mockRepository.Setup(r => r.DeleteAsync(It.IsAny<PersonalTrainer>())).Returns((PersonalTrainer c) =>
            {
                trainers.Remove(c);
                return Task.CompletedTask;
            });


            return mockRepository;
        }
    }
}
