using AutoMapper;
using GymApp.Application.Features.PersonalTrainer.Commands.CreateNewTrainer;
using GymApp.Application.Interfaces.Persistence;
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
    public class CreateNewTrainerCommandValidatorTests
    {
        public CreateNewTrainerCommandValidatorTests()
        {
        }

        [Fact]
        public void CreateTrainerValidator_CorrectData_ReturnsTrue()
        {
            var newTrainer = new NewTrainerDTO
            {
                Name = "Test",
                Surname = "Test",
                Email = "test@test.pl",
                PhoneNumber = "123456789"
            };
            var command = new CreateNewTrainerCommand { NewTrainer = newTrainer };
            var validator = new CreateNewTrainerCommandValidator();
            var result = validator.Validate(command);
            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void CreateTrainerValidator_InvalidName_ReturnsFalse()
        {
            var newTrainer = new NewTrainerDTO
            {
                Name = "Te",
                Surname = "Test",
                Email = "test@test.pl",
                PhoneNumber = "123456789"
            };
            var command = new CreateNewTrainerCommand { NewTrainer = newTrainer };
            var validator = new CreateNewTrainerCommandValidator();
            var result = validator.Validate(command);
            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public void CreateTrainerValidator_InvalidSurname_ReturnsFalse()
        {
            var newTrainer = new NewTrainerDTO
            {
                Name = "Test",
                Surname = "Te",
                Email = "test@test.pl",
                PhoneNumber = "123456789"
            };
            var command = new CreateNewTrainerCommand { NewTrainer = newTrainer };
            var validator = new CreateNewTrainerCommandValidator();
            var result = validator.Validate(command);
            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public void CreateTrainerValidator_InvalidEmail_ReturnsFalse()
        {
            var newTrainer = new NewTrainerDTO
            {
                Name = "Test",
                Surname = "Test",
                Email = "test",
                PhoneNumber = "123456789"
            };
            var command = new CreateNewTrainerCommand { NewTrainer = newTrainer };
            var validator = new CreateNewTrainerCommandValidator();
            var result = validator.Validate(command);
            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public void CreateTrainerValidator_InvalidPhone_ReturnsFalse()
        {
            var newTrainer = new NewTrainerDTO
            {
                Name = "Test",
                Surname = "Test",
                Email = "test@test.pl",
                PhoneNumber = "1234567"
            };
            var command = new CreateNewTrainerCommand { NewTrainer = newTrainer };
            var validator = new CreateNewTrainerCommandValidator();
            var result = validator.Validate(command);
            result.IsValid.ShouldBe(false);
        }

    }
}
