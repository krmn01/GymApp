using AutoMapper;
using GymApp.Application.Exceptions;
using GymApp.Application.Features.PersonalTrainer.Commands.UpdateTrainer;
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

namespace GymApp.UnitTests.Features.PersonalTrainer.Commands.UpdateTrainer
{
    public class UpdateTrainerCommandHandlerTests
    {
        private readonly Mock<IPersonalTrainerRepository> _trainersMock;

        public UpdateTrainerCommandHandlerTests()
        {
            _trainersMock = MockPersonalTrainerRepository.GetTrainers();
        }

        [Fact]
        public async Task UpdateTrainer_CorrectData_ReturnsTrue()
        {
            var updatedTrainer = new UpdateTrainerDTO
            {
                Name = "Updatedname"
            };
            var handler = new UpdateTrainersDataCommandHandler(_trainersMock.Object);
            await handler.Handle(new UpdateTrainersDataCommand { TrainerGuid = Guid.Parse("00000000-0000-0000-0000-000000000003"), UpdatedTrainer = updatedTrainer }, CancellationToken.None);
            var trainer = _trainersMock.Object.GetByIdAsync(Guid.Parse("00000000-0000-0000-0000-000000000003")).Result;
            trainer.Name.ShouldBe(updatedTrainer.Name);
        }

        [Fact]
        public void UpdateTrainer_InvalidTrainer_ThrowsNotFound()
        {
            var updatedTrainer = new UpdateTrainerDTO
            {
                Name = "Updatedname"
            };
            var handler = new UpdateTrainersDataCommandHandler(_trainersMock.Object);
            Should.Throw<NotFoundException>(async () =>
            {
                await handler.Handle(new UpdateTrainersDataCommand { TrainerGuid = Guid.Parse("00000000-0000-0000-0000-000000000022"), UpdatedTrainer = updatedTrainer }, CancellationToken.None);
            });
        }
    }
}
