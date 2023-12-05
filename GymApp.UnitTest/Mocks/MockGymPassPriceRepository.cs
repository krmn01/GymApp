using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Entities;
using GymApp.Domain.Enums;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.UnitTests.Mocks
{
    public class MockGymPassPriceRepository
    {
        public static Mock<IGymPassPriceRepository> GetGymPassPrices()
        {
            var prices = new List<GymPassPrice>
            {
               new GymPassPrice
               {
                   Length = Domain.Enums.GymPassLength.Month,
                   Price = 50
               },
                 new GymPassPrice
               {
                   Length = Domain.Enums.GymPassLength.Quarter,
                   Price = 150
               },
                new GymPassPrice
               {
                   Length = Domain.Enums.GymPassLength.HalfYear,
                   Price = 300
               }
            };

            var mockRepository = new Mock<IGymPassPriceRepository>();

            mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(prices);

            mockRepository.Setup(r => r.GetPriceById(It.IsAny<GymPassLength>())).Returns((GymPassLength id) =>
            {
                try
                {
                    var result = prices.Where(c => c.Length == id).First();
                    return Task.FromResult(result);
                }
                catch
                {
                    GymPassPrice result = null;
                    return Task.FromResult(result);
                }
            });

            mockRepository.Setup(r => r.CreateAsync(It.IsAny<GymPassPrice>()))
                .Returns((GymPassPrice c) =>
                {
                    prices.Add(c);
                    return Task.CompletedTask;
                });

            mockRepository.Setup(r => r.UpdateAsync(It.IsAny<GymPassPrice>())).Returns((GymPassPrice c) =>
            {
                var price = prices.Where(x => x.Length == c.Length).First();
                price = c;
                return Task.CompletedTask;
            });

            mockRepository.Setup(r => r.DeleteAsync(It.IsAny<GymPassPrice>())).Returns((GymPassPrice c) =>
            {
                prices.Remove(c);
                return Task.CompletedTask;
            });


            return mockRepository;

        }
    }
}

