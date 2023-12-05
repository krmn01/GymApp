using GymApp.Application.Features.GymPass.Commands.RenewGymPass;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GymApp.UnitTests.Features.GymPass.Commands.RenewGymPass
{
    public class RenewGymPassCommandValidatorTests
    {
        [Fact]
        public void RenewGymPassCommandValidator_CorrectData_ReturnsTrue()
        {
            var command = new RenewGymPassCommand
            {
                ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                NumberOfDays = 20
            };
            var validator = new RenewGymPassCommandValidator();
            var result = validator.Validate(command);
            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void RenewGymPassCommandValidator_NullProfileId_ReturnsFalse()
        {
            var command = new RenewGymPassCommand
            {
                NumberOfDays = 20
            };
            var validator = new RenewGymPassCommandValidator();
            var result = validator.Validate(command);
            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public void RenewGymPassCommandValidator_InvalidNumberOfDays_ReturnsFalse()
        {
            var command = new RenewGymPassCommand
            {
                ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                NumberOfDays = -1
            };
            var validator = new RenewGymPassCommandValidator();
            var result = validator.Validate(command);
            result.IsValid.ShouldBe(false);
        }
    }
}
