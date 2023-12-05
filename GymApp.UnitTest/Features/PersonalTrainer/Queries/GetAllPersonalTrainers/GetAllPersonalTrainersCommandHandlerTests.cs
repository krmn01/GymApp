using AutoMapper;
using GymApp.Application.Features.PersonalTrainer;
using GymApp.Application.Features.PersonalTrainer.GetAllPersonalTrainers;
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

namespace GymApp.UnitTests.Features.PersonalTrainer.Queries.GetAllPersonalTrainers
{
    public class GetAllPersonalTrainersQueryHandlerTests
    {
        private readonly Mock<IPersonalTrainerRepository> _trainersMocked;
        private readonly IMapper _mapper;
        public GetAllPersonalTrainersQueryHandlerTests()
        {
            _trainersMocked = MockPersonalTrainerRepository.GetTrainers();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<PersonalTrainerMapping>();
                c.AddProfile<ClassMapping>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetAllTrainers_null_ReturnsTrainersList()
        {
            var handler = new GetAllPersonalTrainersQueryHandler(_mapper,_trainersMocked.Object);
            var result = await handler.Handle(new GetAllPersonalTrainersQuery(),CancellationToken.None);
            result.ShouldBeOfType<List<PersonalTrainerDTO>>();
        }
    }
}
