using FluentValidation.Results;
using GymApp.Application.Features.Class.Commands.UpdateClass;
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

namespace GymApp.UnitTests.Features.Class.Commands.UpdateClass
{
    public class UpdateClassCommandValidatorTests
    {
        public UpdateClassCommandValidatorTests()
        {
        }

        private ValidationResult ValidateCommand(UpdateClassDTO updatedClass)
        {
            var command = new UpdateClassCommand { UpdatedClass = updatedClass, ClassId = Guid.Parse("00000000-0000-0000-0000-000000000002") };
            var validator = new UpdateClassCommandValidator();
            return validator.Validate(command);
        }

        [Fact]
        public void UpdateClassValidator_CorrectClassName_ReturnsTrue()
        {
            var updatedClass = new UpdateClassDTO
            {
                ClassName = "Biceps"
            };
            var validationResult = ValidateCommand(updatedClass);
            validationResult.IsValid.ShouldBe(true);
        }

        [Fact]
        public void UpdateClassValidator_InvalidClassName_ReturnsFalse()
        {
            var updatedClass = new UpdateClassDTO
            {
                ClassName = "Up"
            };
            var validationResult = ValidateCommand(updatedClass);
            validationResult.IsValid.ShouldBe(false);
        }

        [Fact]
        public void UpdateClassValidator_CorrectStartTime_ReturnsTrue()
        {
            var updatedClass = new UpdateClassDTO
            {
                StartTime = new DateTime(2023, 12, 12, 14, 0, 0),
                EndTime = new DateTime(2023, 12, 12, 15, 0, 0)
            };
            var validationResult = ValidateCommand(updatedClass);
            validationResult.IsValid.ShouldBe(true);
        }

        [Fact]
        public void UpdateClassValidator_InvalidStartTime_ReturnsFalse()
        {
            var updatedClass = new UpdateClassDTO
            {
                StartTime = new DateTime(2023, 12, 12, 14, 0, 0),
                EndTime = new DateTime(2023, 12, 12, 12, 0, 0)
            };
            var validationResult = ValidateCommand(updatedClass);
            validationResult.IsValid.ShouldBe(false);
        }

        [Fact]
        public void UpdateClassValidator_MaxUsersGreaterThan50_ReturnsFalse()
        {
            var updatedClass = new UpdateClassDTO
            {
               MaxUsers = 52
            };
            var validationResult = ValidateCommand(updatedClass);
            validationResult.IsValid.ShouldBe(false);
        }

        [Fact]
        public void UpdateClassValidator_MaxUsersLessThan1_ReturnsFalse()
        {
            var updatedClass = new UpdateClassDTO
            {
                MaxUsers = 0
            };
            var validationResult = ValidateCommand(updatedClass);
            validationResult.IsValid.ShouldBe(false);
        }

        [Fact]
        public void UpdateClassValidator_MaxUsersInRange_ReturnsTrue()
        {
            var updatedClass = new UpdateClassDTO
            {
                MaxUsers = 10
            };
            var validationResult = ValidateCommand(updatedClass);
            validationResult.IsValid.ShouldBe(true);
        }
    }
}
