using AutoMapper;
using GymApp.Application.Features.PersonalTrainer.Commands.CreateNewTrainer;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Application.Mapping;
using GymApp.UnitTests.Mock;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GymApp.UnitTests.Features.PersonalTrainer.Commands.CreateNewTrainer
{
    public class CreateNewTrainerCommandHandlerTests
    {
        private readonly Mock<IPersonalTrainerRepository> _trainersMock;
        private readonly IMapper _mapper;

        public CreateNewTrainerCommandHandlerTests()
        {
            _trainersMock = MockPersonalTrainerRepository.GetTrainers();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<PersonalTrainerMapping>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task CreateTrainer_CorrectData_ReturnsGuid()
        {
            var newTrainer = new NewTrainerDTO{
                Name = "Test",
                Surname = "Test",
                PhoneNumber = "123456789",
                Email = "test@test.com",
            };

            var handler = new CreateNewTrainerCommandHandler(_mapper,_trainersMock.Object);
            await handler.Handle(new CreateNewTrainerCommand { NewTrainer = newTrainer }, CancellationToken.None);
            var trainers = _trainersMock.Object.GetAllAsync().Result;

            trainers.Count.ShouldBe(4);
        }
    }
}
