using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Entities;
using GymApp.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Persistence.Repositories
{
    public class GymPassRepository : GenericRepository<GymPass>, IGymPassRepository
    {
        public GymPassRepository(GymDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> CheckIfValid(Guid PassId)
        {
            var gymPass = await _context.Set<GymPass>().Where(a => a.Id == PassId).AsNoTracking().FirstAsync();
            return DateTime.Now < gymPass.ValidTill;
        }
    }
}
