using GymApp.Application.Features.ProfilePicture;
using GymApp.Application.Interfaces.Identity;
using GymApp.Application.Models.Identity;
using GymApp.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace GymApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtHelper _jwtHelper;
        private readonly IUserService _userService;
        private readonly IMediator _mediator;

        public UserController(IJwtHelper jwtHelper, IUserService userService, IMediator mediator)
        {
            _jwtHelper = jwtHelper;
            _userService = userService;
            _mediator = mediator;
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

        [HttpPut("change-picture")]
        [Authorize]
        public async Task<Response<string>> ChangePicture([FromHeader(Name = "Authorization")] string token, [FromBody]string picture)
        {
            var id = _jwtHelper.GetIdFromToken(token);
            return await _userService.UpdateProfilePicture(id, Convert.FromBase64String(picture));
        }

        [HttpPut("change-profile-data")]
        [Authorize]
        public async Task<Response<string>> ChangeProfileData([FromHeader(Name = "Authorization")] string token, [FromBody] ChangeUsersDataRequest request)
        {
            var id = _jwtHelper.GetIdFromToken(token);
            return await _userService.ChangeUsersData(id, request);
        }

        [HttpDelete("delete-account")]
        [Authorize]
        public async Task<Response<string>> DeleteUser([FromHeader(Name = "Authorization")] string token, [FromBody] string password)
        {
            var id = _jwtHelper.GetIdFromToken(token);
            return await _userService.DeleteUser(id, password);
        }

       

    }
}
