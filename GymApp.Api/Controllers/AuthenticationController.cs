using GymApp.Application.Interfaces.Identity;
using GymApp.Application.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<AuthResponse> Login([FromBody]AuthRequest request)
        {
            return await _authService.Login(request);   
        }

        [HttpPost("register")]
        public async Task<RegistrationResponse> Register([FromBody] RegistrationRequest request)
        {
            return await _authService.Register(request);
        }
    }
}
