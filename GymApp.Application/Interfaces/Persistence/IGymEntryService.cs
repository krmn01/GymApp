using GymApp.Application.Features.GymEntry;
using GymApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Interfaces.Persistence
{
    public interface IGymEntryService
    {
        Task<Response<string>> AddGymEntry(Guid profileId, int timeInMinutes);
        Task<Response<GymEntriesWeeklyStatsDTO>> GetWeekStats(Guid profileId);
    }
}
