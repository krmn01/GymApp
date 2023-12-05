using GymApp.Application.Exceptions;
using GymApp.Application.Features.GymPass.Commands.UpdateSpecificPrice;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Enums;
using GymApp.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GymApp.UnitTests.Features.GymPass.Commands.UpdateSpecificPrice
{
    public class UpdateSepcificPriceCommandHandlerTests
    {
        private readonly Mock<IGymPassPriceRepository> _pricesMock;

        public UpdateSepcificPriceCommandHandlerTests()
        {
            _pricesMock = MockGymPassPriceRepository.GetGymPassPrices();
        }

        [Fact]
        public async Task UpdatePrice_CorrectData_ReturnsUnit()
        {
            var handler = new UpdateSpecificPriceCommandHandler(_pricesMock.Object);
            await handler.Handle(new UpdateSpecificPriceCommand { GymPassPriceDTO = new Application.Features.GymPass.Queries.GetGymPassPrices.GymPassPriceDTO { Length = "Month", Price = 100 } }, CancellationToken.None);
            var price = await _pricesMock.Object.GetPriceById(GymPassLength.Month);
            price.Price.ShouldBe(100);
        }

        [Fact]
        public void UpdatePrice_InvalidLength_ThrowsBadRequest()
        {
            var handler = new UpdateSpecificPriceCommandHandler(_pricesMock.Object);
            Should.Throw<BadRequestException>(async () =>
            {
                await handler.Handle(new UpdateSpecificPriceCommand { GymPassPriceDTO = new Application.Features.GymPass.Queries.GetGymPassPrices.GymPassPriceDTO { Length = "miesiac", Price = 100 } }, CancellationToken.None);
            });
        }
    }
}
