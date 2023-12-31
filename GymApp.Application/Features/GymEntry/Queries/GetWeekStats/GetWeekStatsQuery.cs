﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.GymEntry.Queries.GetWeekStats
{
    public class GetWeekStatsQuery :IRequest<GymEntriesWeeklyStatsDTO>
    {
        public Guid profileId { get; set; }
    }
}
