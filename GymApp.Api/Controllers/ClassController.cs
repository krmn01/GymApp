using GymApp.Application.Features.Class;
using GymApp.Application.Features.Class.Commands.AddClass;
using GymApp.Application.Features.Class.Commands.UpdateClass;
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

        [HttpPost("{id}/unassign-from-user")]
        [Authorize]
        public async Task<Response<string>> UnassignClassFromUser([FromHeader(Name = "Authorization")] string token, string id)
        {
            return await _classService.UnassignClassFromUserAsync(_jwtHelper.GetProfileIdFromToken(token), Guid.Parse(id));
        }

        [HttpPost("add-class")]
        [Authorize(Roles = "Administrator")]
        public async Task<Response<string>> AddNewClass(AddClassDTO newClass)
        {
            return await _classService.AddNewClassAsync(newClass);
        }


        [HttpGet("users-classes")]
        [Authorize]
        public async Task<Response<List<ClassDTO>>> GetUsersClasses([FromHeader(Name = "Authorization")] string token)
        {
            return await _classService.GetUsersClassesAsync(_jwtHelper.GetProfileIdFromToken(token));
        }

        [HttpPatch("{id}/update")]
        [Authorize(Roles = "Administrator")]
        public async Task<Response<string>> UpdateClass(string id, UpdateClassDTO dto)
        {
            return await _classService.UpdateClassAsync(id,dto);
        }

        [HttpDelete("{id}/delete")]
        [Authorize(Roles = "Administrator")]
        public async Task<Response<string>> DeleteClass(string id)
        {
            return await _classService.DeleteClassAsync(id);
        }
    }
}
