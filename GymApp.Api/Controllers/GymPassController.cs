using GymApp.Application.Features.GymPass.Requests.GetGymPass;
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
    public class GymPassController : ControllerBase
    {
        private readonly IGymPassService _gymPassService;
        private readonly IJwtHelper _jwtHelper;

        public GymPassController(IGymPassService gymPassService, IJwtHelper jwtHelper)
        {
            _gymPassService = gymPassService;
            _jwtHelper = jwtHelper;
        }

        [HttpPost("renew")]
        [Authorize]
        public async Task<Response<string>> RenewGymPassAsync([FromHeader(Name = "Authorization")] string token, [FromBody]int days)
        {
            return await _gymPassService.RenewAsync(_jwtHelper.GetProfileIdFromToken(token), days);
        }

        [HttpGet("get")]
        [Authorize]
        public async Task<Response<GymPassDTO>> GetGymPassAsync([FromHeader(Name = "Authorization")] string token)
        {
            return await _gymPassService.GetAsync(_jwtHelper.GetProfileIdFromToken(token));
        }
    }
}
