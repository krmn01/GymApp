using AutoMapper;
using GymApp.Application.Exceptions;
using GymApp.Application.Features.GymPass.Queries.GetGymPass;
using GymApp.Application.Features.GymPass.Queries.GetGymPassPrices;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Application.Mapping;
using GymApp.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GymApp.UnitTests.Features.GymPass.Queries.GetGymPassPrices
{
    public class GetGymPassPricesQueryHandlerTests
    {
        private readonly Mock<IGymPassPriceRepository> _pricesMock;
        private readonly IMapper _mapper;

        public GetGymPassPricesQueryHandlerTests()
        {
            _pricesMock = MockGymPassPriceRepository.GetGymPassPrices();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<GymPassPriceMapping>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetGymPass_CorrectData_ReturnsListOfPrices()
        {
            var handler = new GetGymPassPricesQueryHandler(_pricesMock.Object, _mapper);
            var result = await handler.Handle(new GetGymPassPricesQuery {}, CancellationToken.None);
            result.ShouldBeOfType<List<GymPassPriceDTO>>();
        }
    }
}
