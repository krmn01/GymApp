using GymApp.Application.Features.TrainingGoal;
using GymApp.Application.Interfaces.Identity;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Common;
using GymApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingGoalController : ControllerBase
    {
        private readonly ITrainingGoalService _goalService;
        private readonly IJwtHelper _jwtHelper;
        public TrainingGoalController(ITrainingGoalService goalService,IJwtHelper jwtHelper)
        {
            _goalService = goalService;
            _jwtHelper = jwtHelper;
        }

        [HttpGet("get-all")]
        [Authorize]
        public async Task<Response<List<TrainingGoalDTO>>> GetTrainingGoalsById([FromHeader(Name = "Authorization")] string token)
        {
            return await _goalService.GetTrainingGoalsById(_jwtHelper.GetProfileIdFromToken(token));
        }

        [HttpPost("add")]
        [Authorize]
        public async Task<Response<string>> AddTrainingGoal([FromHeader(Name = "Authorization")] string token, [FromBody]string content)
        {
            return await _goalService.AddTrainingGoal(_jwtHelper.GetProfileIdFromToken(token),content);
        }
    }
}
