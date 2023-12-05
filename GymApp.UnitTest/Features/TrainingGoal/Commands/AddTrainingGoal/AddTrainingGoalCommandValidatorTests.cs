using GymApp.Application.Features.TrainingGoal.Commands.AddTrainingGoal;
using GymApp.Application.Interfaces.Persistence;
using GymApp.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GymApp.UnitTests.Features.TrainingGoal.Commands.AddTrainingGoal
{
    public class AddTrainingGoalCommandValidatorTests
    {

        [Fact]
        public void AddTrainingGoalValidator_EmptyContent_ReturnFalse()
        {
            var command = new AddTrainingGoalCommand
            {
                ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                TrainingGoalDTO = new Application.Features.TrainingGoal.TrainingGoalDTO
                {
                    Content = string.Empty,
                    Finished = false,
                    Id = new Guid()
                }
            };
            var validator = new AddTrainingGoalCommandValidator();
            var result = validator.Validate(command);
            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public void AddTrainingGoalValidator_ContentShorterThan5Chars_ReturnFalse()
        {
            var command = new AddTrainingGoalCommand
            {
                ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                TrainingGoalDTO = new Application.Features.TrainingGoal.TrainingGoalDTO
                {
                    Content = "abcd",
                    Finished = false,
                    Id = new Guid()
                }
            };
            var validator = new AddTrainingGoalCommandValidator();
            var result = validator.Validate(command);
            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public void AddTrainingGoalValidator_ContentLongerThan40Chars_ReturnFalse()
        {
            var command = new AddTrainingGoalCommand
            {
                ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                TrainingGoalDTO = new Application.Features.TrainingGoal.TrainingGoalDTO
                {
                    Content = "abcddasdasdsaaaaaadsaaaaaaaaaaaaaaaaaaaaaaaaaaaadddddddddsaaaaaaadsadasd",
                    Finished = false,
                    Id = new Guid()
                }
            };
            var validator = new AddTrainingGoalCommandValidator();
            var result = validator.Validate(command);
            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public void AddTrainingGoalValidator_ProfileIdNull_ReturnFalse()
        {
            var command = new AddTrainingGoalCommand
            {
                TrainingGoalDTO = new Application.Features.TrainingGoal.TrainingGoalDTO
                {
                    Content = "abcddasddsaaaaaadsadasd",
                    Finished = false,
                    Id = new Guid()
                }
            };
            var validator = new AddTrainingGoalCommandValidator();
            var result = validator.Validate(command);
            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public void AddTrainingGoalValidator_CorrectData_ReturnTrue()
        {
            var command = new AddTrainingGoalCommand
            {
                ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                TrainingGoalDTO = new Application.Features.TrainingGoal.TrainingGoalDTO
                {
                    Content = "abcddasddsaaaaaadsadasd",
                    Finished = false,
                    Id = new Guid()
                }
            };
            var validator = new AddTrainingGoalCommandValidator();
            var result = validator.Validate(command);
            result.IsValid.ShouldBe(true);
        }
    }
}
