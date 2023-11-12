using GymApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Interfaces.Persistence
{
    public interface IGymEntryRepository :IGenericRepository<GymEntry>
    {
        Task<TimeSpan> GetTotalWeekTime(Guid gymPassId);
        Task<int> GetWeekEntriesCount(Guid gymPassId);
    }
}
