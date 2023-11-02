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
    public class GymEntryRepository : GenericRepository<GymEntry>, IGymEntryRepository
    {
        public GymEntryRepository(GymDatabaseContext context) : base(context)
        {
        }

        public async Task<int> GetWeekEntriesCount(Guid gymPassId)
        {
            var entries = await _context.Set<GymEntry>().Where(a => a.GymPassId == gymPassId).AsNoTracking().ToListAsync();
            return entries.Count;
        }

        public async Task<TimeSpan> GetTotalWeekTime(Guid gymPassId)
        {
            var entries = await _context.Set<GymEntry>().Where(a => a.GymPassId == gymPassId).AsNoTracking().ToListAsync();
            TimeSpan time = new(0,0,0);
            foreach (var entry in entries)
            {
                time += (TimeSpan)(entry.ExitedOn - entry.EnteredOn) != null ? (TimeSpan)(entry.ExitedOn - entry.EnteredOn) : new TimeSpan(0,0,0); 
            }
            return time;
        }
    }
}
