using FluentValidation.Results;
using GymApp.Application.Features.PersonalTrainer.Commands.UpdateTrainer;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GymApp.UnitTests.Features.PersonalTrainer.Commands.UpdateTrainer
{
    public class UpdateTrainerCommandValidatorTests
    {
        public UpdateTrainerCommandValidatorTests()
        {
        }

        private ValidationResult ValidateCommand(UpdateTrainerDTO updatedTrainer)
        {
            var command = new UpdateTrainersDataCommand { TrainerGuid = Guid.Parse("00000000-0000-0000-0000-000000000003"), UpdatedTrainer = updatedTrainer };
            var validator = new UpdateTrainersDataCommandValidator();
            return validator.Validate(command);
        }

        [Fact]
        public void UpdateTrainerValidator_CorrectName_ReturnsTrue()
        {
            var updatedTrainer = new UpdateTrainerDTO
            {
                Name = "Adam"
            };
            var result = ValidateCommand(updatedTrainer);
            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void UpdateTrainerValidator_InvalidName_ReturnsFalse()
        {
            var updatedTrainer = new UpdateTrainerDTO
            {
                Name = "as"
            };
            var result = ValidateCommand(updatedTrainer);
            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public void UpdateTrainerValidator_CorrectSurname_ReturnsTrue()
        {
            var updatedTrainer = new UpdateTrainerDTO
            {
                Surname = "Adamek"
            };
            var result = ValidateCommand(updatedTrainer);
            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void UpdateTrainerValidator_InvalidSurname_ReturnsFalse()
        {
            var updatedTrainer = new UpdateTrainerDTO
            {
                Surname = "as"
            };
            var result = ValidateCommand(updatedTrainer);
            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public void UpdateTrainerValidator_CorrectEmail_ReturnsTrue()
        {
            var updatedTrainer = new UpdateTrainerDTO
            {
                Email = "adam@wp.pl"
            };
            var result = ValidateCommand(updatedTrainer);
            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void UpdateTrainerValidator_InvalidEmail_ReturnsFalse()
        {
            var updatedTrainer = new UpdateTrainerDTO
            {
                Email = "email"
            };
            var result = ValidateCommand(updatedTrainer);
            result.IsValid.ShouldBe(false);
        }


        [Fact]
        public void UpdateTrainerValidator_CorrectPhoneNo_ReturnsTrue()
        {
            var updatedTrainer = new UpdateTrainerDTO
            {
                PhoneNumber = "555444333"
            };
            var result = ValidateCommand(updatedTrainer);
            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void UpdateTrainerValidator_InvalidPhoneNo_ReturnsFalse()
        {
            var updatedTrainer = new UpdateTrainerDTO
            {
                PhoneNumber = "1234"
            };
            var result = ValidateCommand(updatedTrainer);
            result.IsValid.ShouldBe(false);
        }
    }
}
