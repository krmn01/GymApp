using GymApp.Application.Features.PersonalTrainer;
using GymApp.Application.Features.PersonalTrainer.Commands.CreateNewTrainer;
using GymApp.Application.Interfaces.Identity;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalTrainerController : ControllerBase
    {
        private readonly IPersonalTrainerService _trainerService;
        private readonly IJwtHelper _jwtHelper;
        public PersonalTrainerController(IPersonalTrainerService trainerService, IJwtHelper jwtHelper)
        {
            _trainerService = trainerService;
            _jwtHelper = jwtHelper;
        }

        [HttpGet("get-all")]
        [Authorize]
        public async Task<Response<List<PersonalTrainerDTO>>> GetAllTrainers([FromHeader(Name = "Authorization")] string token)
        {
            return await _trainerService.GetAllTrainers();
        }

        [HttpPost("create")]
        [Authorize(Roles = "Administrator")]
        public async Task<Response<string>> CreateNewTrainer([FromBody] NewTrainerDTO newTrainer)
        {
            return await _trainerService.CreateNewTrainer(newTrainer);
        }
    }
}
