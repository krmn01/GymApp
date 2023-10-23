using GymApp.Application.Exceptions;
using GymApp.Application.Interfaces.Identity;
using GymApp.Application.Models.Identity;
using GymApp.Domain.Common;
using GymApp.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserService(UserManager<ApplicationUser> userManager,  SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _userManager.GetUsersInRoleAsync("User");
            return users.Select(x => new User
            {
                Id = x.Id,
                FullName = x.FullName,
                UserName = x.UserName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,

            }).ToList();
        }

        public async Task<GetUserResponse> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) throw new NotFoundException(id, typeof(User).ToString());
            var applicationUser = new User
            {
                Id = user.Id,
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };

            return new GetUserResponse
            {
                Succeeded = true,
                Data = applicationUser,
                StatusCode = 200,
            };
        }


        public async Task<Response<string>> UpdatePasswordAsync(string id,UpdatePasswordRequest request)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) throw new BadRequestException("User does not exist", new FluentValidation.Results.ValidationResult());
            if (!request.NewPassword.Equals(request.ConfirmPassword)) throw new BadRequestException("Passwords are not the same", new FluentValidation.Results.ValidationResult());
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.CurrentPassword, false);
            
            if (!result.Succeeded) throw new BadRequestException("Incorrect current password", new FluentValidation.Results.ValidationResult());
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var passwordChangeResult = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);

            if(!passwordChangeResult.Succeeded) throw new BadRequestException("Something went wrong when changing password", new FluentValidation.Results.ValidationResult());
            return new Response<string>
            {
                StatusCode = 200,
                Succeeded = true,
                Errors = null,
                Message = "Password changed",
                Data = null
            };
        }
    }
}
