using AutoMapper;
using GymApp.Application.Exceptions;
using GymApp.Application.Features.PersonalTrainer.Commands.DeleteTrainer;
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

namespace GymApp.UnitTests.Features.PersonalTrainer.Commands.DeleteTrainer
{
    public class DeleteTrainerCommandHandlerTests
    {
        private readonly Mock<IPersonalTrainerRepository> _trainersMock;

        public DeleteTrainerCommandHandlerTests()
        {
            _trainersMock = MockPersonalTrainerRepository.GetTrainers();
        }

        [Fact]
        public async Task DeleteTrainer_CorrectData_ReturnsUnit()
        {
            var handler = new DeleteTrainerCommandHandler(_trainersMock.Object);
            await handler.Handle(new DeleteTrainerCommand { TrainerId = Guid.Parse("00000000-0000-0000-0000-000000000003") }, CancellationToken.None);
            var trainers = _trainersMock.Object.GetAllAsync().Result;
            trainers.Count.ShouldBe(2);
        }

        [Fact]
        public void DeleteTrainer_InvalidTrainer_ThrowsNotFound()
        {
            var handler = new DeleteTrainerCommandHandler(_trainersMock.Object);
            Should.Throw<NotFoundException>(async () =>
            {
                await handler.Handle(new DeleteTrainerCommand { TrainerId = Guid.Parse("00000000-0000-0000-0000-000000000013") }, CancellationToken.None);
            });
        }
    }
}
