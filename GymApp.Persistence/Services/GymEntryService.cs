using AutoMapper;
using GymApp.Application.Features.GymEntry;
using GymApp.Application.Features.GymEntry.Commands.AddGymEntry;
using GymApp.Application.Features.GymEntry.Queries.GetWeekStats;
using GymApp.Application.Features.GymEntry.Queries.GetWeekStatsRank;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Persistence.Services
{
    public class GymEntryService : IGymEntryService
    {
        private IMediator _mediator;

        public GymEntryService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Response<string>> AddGymEntry(Guid profileId, int timeInMinutes)
        {
           var request = new AddGymEntryCommand { profileId = profileId, timeInMinutes = timeInMinutes };
           var response = await _mediator.Send(request);
            return new Response<string>
            {
                StatusCode = 200,
                Succeeded = true,
                Message = "Gym entry added",
                Data = response.ToString()
            };
        }

        public async Task<Response<List<GymEntriesWeeklyStatsDTO>>> GetWeekRank()
        {
            var request = new GetWeekStatsRankQuery();
            var response = await _mediator.Send(request);
            return new Response<List<GymEntriesWeeklyStatsDTO>> { StatusCode = 200, Succeeded = true, Data = response };
        }

        public async Task<Response<GymEntriesWeeklyStatsDTO>> GetWeekStats(Guid profileId)
        {
            var request = new GetWeekStatsQuery { profileId = profileId };
            var response = await _mediator.Send(request);
            return new Response<GymEntriesWeeklyStatsDTO> { StatusCode = 200, Succeeded = true, Data = response };
        }
    }
}
