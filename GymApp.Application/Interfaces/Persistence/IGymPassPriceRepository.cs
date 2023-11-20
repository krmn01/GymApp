using GymApp.Domain.Entities;
using GymApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Interfaces.Persistence
{
    public interface IGymPassPriceRepository :IGenericRepository<GymPassPrice>
    {
        public Task<GymPassPrice> GetPriceById(GymPassLength length);
    }
}
