using AutoMapper;
using GymApp.Application.Interfaces.Persistence;
using GymApp.UnitTests.Mock;
using Moq;
using Xunit;
using GymApp.Application.Mapping;
using GymApp.Application.Features.PersonalTrainer.GetAllPersonalTrainers;
using GymApp.Application.Features.PersonalTrainer.Queries.GetPersonalTrainerById;
using Shouldly;
using GymApp.Application.Features.PersonalTrainer;
using GymApp.Application.Exceptions;

namespace GymApp.UnitTests.Features.PersonalTrainer.Queries.GetPersonalTrainerById
{
    public class GetPersonalTrainerByIdCommandHandlerTests
    {
        private readonly Mock<IPersonalTrainerRepository> _trainersMocked;
        private readonly IMapper _mapper;
        public GetPersonalTrainerByIdCommandHandlerTests()
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
        public async Task GetTrainerById_CorrectData_ReturnsTrainer()
        {
            var handler = new GetPersonalTrainerByIdQueryHandler(_trainersMocked.Object, _mapper);
            var trainer = await handler.Handle(new GetPersonalTrainerByIdQuery { Id = Guid.Parse("00000000-0000-0000-0000-000000000003") }, CancellationToken.None);
            trainer.ShouldBeOfType<PersonalTrainerDTO>();
        }

        [Fact]
        public void GetTrainerById_InvalidTrainer_ThrowsNotFound()
        {
            var handler = new GetPersonalTrainerByIdQueryHandler(_trainersMocked.Object, _mapper);
            Should.Throw<NotFoundException>(async () =>
            {
                await handler.Handle(new GetPersonalTrainerByIdQuery { Id = Guid.Parse("00000000-0000-0000-0000-000000000013") }, CancellationToken.None);
            });
        }
    }
}
