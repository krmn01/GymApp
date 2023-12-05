using AutoMapper;
using GymApp.Application.Features.Class;
using GymApp.Application.Features.Class.Commands.AddClass;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Application.Mapping;
using GymApp.UnitTests.Mock;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using MediatR;
using GymApp.Application.Exceptions;

namespace GymApp.UnitTests.Features.Class.Commands.AddClass
{
    public class AddClassCommandHandlerTests
    {
        private readonly Mock<IPersonalTrainerRepository> _trainersMock;
        private readonly Mock<IClassRepository> _classesMock;
        private readonly IMapper _mapper;

        public AddClassCommandHandlerTests()
        {
            _trainersMock = MockPersonalTrainerRepository.GetTrainers();
            _classesMock = MockClassRepository.GetClasses();
            
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ClassMapping>();
            });

           _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task AddClass_CorrectData_ReturnUnit()
        {
            var handler = new AddClassCommandHandler(_classesMock.Object, _trainersMock.Object, _mapper);
            var newClass =  new AddClassDTO
            {
                    ClassName = "Nowa zajecia",
                    MaxUsers = 10,
                    StartTime = "12-12-2023 10:00",
                    EndTime = "12-12-2023 11:00",
                    TrainerId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    DayOfWeek = "monday",
            };

            await handler.Handle(new AddClassCommand { ClassDTO = newClass }, CancellationToken.None);
            var repositoryCount = _classesMock.Object.GetAllAsync().Result;

            repositoryCount.Count.ShouldBe(4);
        }

        [Fact]
        public void AddClass_InvalidTrainerId_ThrowsNotFoundException()
        {
            var handler = new AddClassCommandHandler(_classesMock.Object, _trainersMock.Object, _mapper);
            var newClass = new AddClassDTO
            {
                ClassName = "Nowa zajecia",
                MaxUsers = 10,
                StartTime = "12-12-2023 10:00",
                EndTime = "12-12-2023 11:00",
                TrainerId = Guid.Parse("00000000-0000-0000-0000-000000001111"),
                DayOfWeek = "monday",
            };
            Should.Throw<NotFoundException>(async () => { 
                await handler.Handle(new AddClassCommand { ClassDTO = newClass }, CancellationToken.None);
            });
        }
    }
}
