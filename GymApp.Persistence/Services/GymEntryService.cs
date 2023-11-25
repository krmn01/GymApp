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
            try
            {
                var response = await _mediator.Send(request);
                return new SuccessRequestResponse<string>("Gym entry added",response.ToString());
            }catch (Exception ex)
            {
                return new BadRequestResponse<string>(ex.Message);
            }
        }

        public async Task<Response<List<GymEntriesWeeklyStatsDTO>>> GetWeekRank()
        {
            var request = new GetWeekStatsRankQuery();
            try
            {
                var response = await _mediator.Send(request);
                return new SuccessRequestResponse<List<GymEntriesWeeklyStatsDTO>>(data: response);
            }catch(Exception ex)
            {
                return new BadRequestResponse<List<GymEntriesWeeklyStatsDTO>>(ex.Message);
            }
        }

        public async Task<Response<GymEntriesWeeklyStatsDTO>> GetWeekStats(Guid profileId)
        {
            var request = new GetWeekStatsQuery { profileId = profileId };
            try
            {
                var response = await _mediator.Send(request);
                return new SuccessRequestResponse<GymEntriesWeeklyStatsDTO>(data: response);
            }catch(Exception ex)
            {
                return new BadRequestResponse<GymEntriesWeeklyStatsDTO>(ex.Message);
            }
        }
    }
}
