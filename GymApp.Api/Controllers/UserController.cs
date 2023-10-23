using GymApp.Application.Interfaces.Identity;
using GymApp.Application.Models.Identity;
using GymApp.Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtHelper _jwtHelper;
        private readonly IUserService _userService;

        public UserController(IJwtHelper jwtHelper, IUserService userService)
        {
            _jwtHelper = jwtHelper;
            _userService = userService;
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<GetUserResponse> GetUser([FromHeader(Name = "Authorization")] string token)
        {
            var id = _jwtHelper.GetIdFromToken(token);
            return await _userService.GetUserById(id);
        }

        [HttpPut("change-password")]
        [Authorize]
        public async Task<Response<string>> ChangePassword([FromHeader(Name = "Authorization")] string token, UpdatePasswordRequest request)
        {
            var id = _jwtHelper.GetIdFromToken(token);
            return await _userService.UpdatePasswordAsync(id,request);
        }

    }
}
