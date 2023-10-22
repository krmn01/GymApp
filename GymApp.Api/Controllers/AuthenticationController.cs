using GymApp.Application.Interfaces.Identity;
using GymApp.Application.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IJwtHelper _jwtHelper;

        public AuthenticationController(IAuthService authService, IJwtHelper jwtHelper, IUserService userService)
        {
            _authService = authService;
            _jwtHelper = jwtHelper;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<AuthResponse> Login([FromBody]AuthRequest request)
        {
            return await _authService.Login(request);   
        }

        [HttpPost("register")]
        public async Task<RegistrationResponse> Register([FromBody]RegistrationRequest request)
        {
            return await _authService.Register(request);
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<GetUserResponse> GetUser([FromHeader(Name = "Authorization")] string token)
        {
            var id = _jwtHelper.GetIdFromToken(token);
            return await _userService.GetUserById(id);
        }
    }
}
