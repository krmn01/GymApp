using AutoMapper;
using GymApp.Application.Features.Class.Commands.AddClass;
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

namespace GymApp.UnitTests.Features.Class.Commands.AddClass
{
    public class AddClassCommandValidatorTests
    {
        public AddClassCommandValidatorTests()
        {
        }

        [Fact]
        public void AddClassValidator_CorrectData_ReturnsTrue()
        {
            var newClass = new AddClassDTO
            {
                ClassName = "Nowa zajecia",
                MaxUsers = 10,
                StartTime = "12-12-2023 10:00",
                EndTime = "12-12-2023 11:00",
                TrainerId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                DayOfWeek = "monday",
            };

            var command = new AddClassCommand { ClassDTO = newClass };
            var validator = new AddClassCommandValidator();
            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void AddClassValidator_NullClassName_ReturnsFalse()
        {
            var newClass = new AddClassDTO
            {
                MaxUsers = 10,
                StartTime = "12-12-2023 10:00",
                EndTime = "12-12-2023 11:00",
                TrainerId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                DayOfWeek = "monday",
            };

            var command = new AddClassCommand { ClassDTO = newClass };
            var validator = new AddClassCommandValidator();
            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public void AddClassValidator_NullMaxUsers_ReturnsFalse()
        {
            var newClass = new AddClassDTO
            {
                ClassName = "Nowa zajecia",
                StartTime = "12-12-2023 10:00",
                EndTime = "12-12-2023 11:00",
                TrainerId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                DayOfWeek = "monday",
            };

            var command = new AddClassCommand { ClassDTO = newClass };
            var validator = new AddClassCommandValidator();
            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public void AddClassValidator_MaxUsersLessThan1_ReturnsFalse()
        {
            var newClass = new AddClassDTO
            {
                ClassName = "Nowa zajecia",
                MaxUsers = 0,
                StartTime = "12-12-2023 10:00",
                EndTime = "12-12-2023 11:00",
                TrainerId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                DayOfWeek = "monday",
            };

            var command = new AddClassCommand { ClassDTO = newClass };
            var validator = new AddClassCommandValidator();
            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public void AddClassValidator_MaxUsersGreaterThan50_ReturnsFalse()
        {
            var newClass = new AddClassDTO
            {
                ClassName = "Nowa zajecia",
                MaxUsers = 52,
                StartTime = "12-12-2023 10:00",
                EndTime = "12-12-2023 11:00",
                TrainerId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                DayOfWeek = "monday",
            };

            var command = new AddClassCommand { ClassDTO = newClass };
            var validator = new AddClassCommandValidator();
            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public void AddClassValidator_StartTimeGreaterThanEndTime_ReturnsFalse()
        {
            var newClass = new AddClassDTO
            {
                ClassName = "Nowa zajecia",
                MaxUsers = 10,
                StartTime = "12-12-2023 10:00",
                EndTime = "12-12-2023 9:00",
                TrainerId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                DayOfWeek = "monday",
            };

            var command = new AddClassCommand { ClassDTO = newClass };
            var validator = new AddClassCommandValidator();
            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
