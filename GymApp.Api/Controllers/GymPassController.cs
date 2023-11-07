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
        public async Task<Response<string>> UnassignClassFromUser([FromHeader(Name = "Authorization")] string token, [FromBody]int days)
        {
            return await _gymPassService.RenewAsync(_jwtHelper.GetProfileIdFromToken(token), days);
        }
    }
}
