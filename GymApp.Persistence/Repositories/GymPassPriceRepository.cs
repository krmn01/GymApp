using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Entities;
using GymApp.Domain.Enums;
using GymApp.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Persistence.Repositories
{
    public class GymPassPriceRepository : GenericRepository<GymPassPrice>, IGymPassPriceRepository
    {
        public GymPassPriceRepository(GymDatabaseContext context) : base(context)
        {
        }

        public async Task<GymPassPrice> GetPriceById(GymPassLength length)
        { 
           return await _context.Set<GymPassPrice>().FindAsync(length);
        }
    }
}
