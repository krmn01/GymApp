using GymApp.Application.Exceptions;
using GymApp.Application.Interfaces.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Identity.Helpers
{
    public class JwtHelper : IJwtHelper
    {
        public string GetIdFromToken(string token)
        {
            var jwtEncodedString = token.Substring(7);
            var newToken = new JwtSecurityToken(jwtEncodedString);
            var id = newToken.Claims.FirstOrDefault(claim => claim.Type == "uId");
            if (id == null) throw new Exception("Token is not valid");
            return id.ToString().Substring(5);
        }

        public Guid GetProfileIdFromToken(string token)
        {
            var jwtEncodedString = token.Substring(7);
            var newToken = new JwtSecurityToken(jwtEncodedString);
            var id = newToken.Claims.FirstOrDefault(claim => claim.Type == "pId");
            if (id == null) throw new Exception("Token is not valid");
            return Guid.Parse(id.ToString().Substring(5));
        }
    }
}
