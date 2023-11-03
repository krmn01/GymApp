using GymApp.Application.Features.Class;
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
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        private readonly IJwtHelper _jwtHelper;
        public ClassController(IClassService classService, IJwtHelper jwtHelper)
        {
            _classService = classService;
            _jwtHelper = jwtHelper;
        }

        [HttpPost("{id}/assign-to-user")]
        [Authorize]
        public async Task<Response<string>> AssignClassToUser([FromHeader(Name = "Authorization")] string token, string id)
        {
            return await _classService.AssignUserToClassAsync(_jwtHelper.GetProfileIdFromToken(token),Guid.Parse(id));
        }

        [HttpGet("users-classes")]
        [Authorize]
        public async Task<Response<List<ClassDTO>>> GetUsersClasses([FromHeader(Name = "Authorization")] string token)
        {
            return await _classService.GetUsersClassesAsync(_jwtHelper.GetProfileIdFromToken(token));
        }
    }
}
