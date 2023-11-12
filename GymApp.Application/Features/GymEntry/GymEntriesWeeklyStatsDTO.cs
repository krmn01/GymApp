using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.GymEntry
{
    public class GymEntriesWeeklyStatsDTO
    {
        public int numberOfEntries { get; set; } = 0;
        public TimeSpan timeSpent {  get; set; }
    }
}
