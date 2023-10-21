using FluentValidation.Validators;
using GymApp.Application.Exceptions;
using GymApp.Application.Interfaces.Identity;
using GymApp.Application.Models.Identity;
using GymApp.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) throw new NotFoundException(request.Email,"email");
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded) throw new BadRequestException("Invalid email or password", null);

            JwtSecurityToken token = await GenerateToken(user);

            return new AuthResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var claimRole = roles.Select(x => new Claim(ClaimTypes.Role,x)).ToList();

            var userClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.FullName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uId", user.Id),
            }
            .Union(claims)
            .Union(claimRole);

            var ssKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(ssKey, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: creds);

            return jwtToken;
        }

         public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            if (!request.Password.Equals(request.ConfirmPassword)) throw new BadRequestException("Passwords are not the same", new FluentValidation.Results.ValidationResult());
            var user = new ApplicationUser
            {
                UserName = request.UserName,
                FullName = request.FullName,
                Email = request.Email,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return new RegistrationResponse
                {
                    StatusCode = 200,
                    Errors = null,
                    Data = user.Id,
                    Message = "Account created successfully"
                };
            }
            throw new BadRequestException($"Something went wrong when creating user: {result.Errors}", new FluentValidation.Results.ValidationResult());
        }
    }
}
