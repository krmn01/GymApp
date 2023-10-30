using GymApp.Application.Features.TrainingGoal;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Common;
using GymApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingGoalController : ControllerBase
    {
        private readonly ITrainingGoalService _goalService;

        public TrainingGoalController(ITrainingGoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpGet("get/{Id}")]
        public async Task<Response<List<TrainingGoalDTO>>> GetTrainingGoalsById(Guid Id)
        {
            return await _goalService.GetTrainingGoalsById(Id);
        }
    }
}
