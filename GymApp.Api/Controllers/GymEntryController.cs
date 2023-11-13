using GymApp.Application.Features.GymEntry;
using GymApp.Application.Interfaces.Identity;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Common;
using GymApp.Persistence.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GymEntryController : ControllerBase
    {
        private readonly IJwtHelper _jwtHelper;
        private readonly IGymEntryService _gymEntryService;

        public GymEntryController(IJwtHelper jwtHelper, IGymEntryService gymEntryService)
        {
            _gymEntryService = gymEntryService;
            _jwtHelper = jwtHelper;
        }

        [HttpPost("add-entry")]
        [Authorize]
        public async Task<Response<string>> AddGymEntry([FromHeader(Name = "Authorization")] string token, [FromBody] int timeInMinutes)
        {
            return await _gymEntryService.AddGymEntry(_jwtHelper.GetProfileIdFromToken(token), timeInMinutes);
        }

        [HttpGet("get-week-stats")]
        [Authorize]
        public async Task<Response<GymEntriesWeeklyStatsDTO>> GetWeekStatsById([FromHeader(Name = "Authorization")] string token)
        {
            return await _gymEntryService.GetWeekStats(_jwtHelper.GetProfileIdFromToken(token));
        }

        [HttpGet("get-rank")]
        [Authorize]
        public async Task<Response<List<GymEntriesWeeklyStatsDTO>>> GetWeekRank()
        {
            return await _gymEntryService.GetWeekRank();
        }
    }
}
