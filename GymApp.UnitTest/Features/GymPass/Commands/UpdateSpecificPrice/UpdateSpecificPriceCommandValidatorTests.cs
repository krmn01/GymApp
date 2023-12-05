using GymApp.Application.Features.GymPass.Commands.UpdateSpecificPrice;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GymApp.UnitTests.Features.GymPass.Commands.UpdateSpecificPrice
{
    public class UpdateSpecificPriceCommandValidatorTests
    {
        [Fact]
        public void UpdatePriceValidator_InvalidPrice_ReturnsFalse()
        {
            var command = new UpdateSpecificPriceCommand
            {
                GymPassPriceDTO = new Application.Features.GymPass.Queries.GetGymPassPrices.GymPassPriceDTO
                {
                    Length = "Month",
                    Price = -100
                }
            };
            var validator = new UpdateSpecificPriceCommandValidator();
            var result = validator.Validate(command);
            result.IsValid.ShouldBeFalse();
        }

        [Fact]
        public void UpdatePriceValidator_CorrectData_ReturnsTrue()
        {
            var command = new UpdateSpecificPriceCommand
            {
                GymPassPriceDTO = new Application.Features.GymPass.Queries.GetGymPassPrices.GymPassPriceDTO
                {
                    Length = "Month",
                    Price = 100
                }
            };
            var validator = new UpdateSpecificPriceCommandValidator();
            var result = validator.Validate(command);
            result.IsValid.ShouldBeTrue();
        }
    }
}
