using GymApp.Application.Exceptions;
using GymApp.Application.Features.ProfilePicture.Commands.UpdatePicture;
using GymApp.Application.Features.ProfilePicture.Queries.GetPicture;
using GymApp.Application.Interfaces.Identity;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Application.Models.Identity;
using GymApp.Domain.Common;
using GymApp.Domain.Entities;
using GymApp.Identity.Models;
using MediatR;
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
        private readonly IMediator _mediator;
        private readonly IUsersProfileRepository _usersProfileRepository;
        public UserService(UserManager<ApplicationUser> userManager,  SignInManager<ApplicationUser> signInManager, IMediator mediator, IUsersProfileRepository usersProfileRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mediator = mediator;
            _usersProfileRepository = usersProfileRepository;

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
            var profile = await _usersProfileRepository.GetByIdAsync(user.UserProfileId);
            if (profile == null) throw new NotFoundException(user.UserProfileId, typeof(UsersProfile).ToString());

            var picture = await _mediator.Send(new GetPictureQuery
            {
                Id = profile.ProfilePictureId
            });

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
                Data = new ProfileDTO{
                    User = applicationUser,
                    ProfilePictureDTO = picture
                },
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

        public async Task<Response<string>> UpdateProfilePicture(string id, byte[] picture)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(picture == null) throw new BadRequestException("Invalid picture", new FluentValidation.Results.ValidationResult());
            var profile = await _usersProfileRepository.GetByIdAsync(user.UserProfileId);
            if (profile == null) throw new NotFoundException(user.UserProfileId, typeof(UsersProfile).ToString());

            var request = new UpdatePictureCommand
            {
                Id = profile.ProfilePictureId,
                Content = picture
            };

            var result = await _mediator.Send(request);
            profile.ProfilePictureId = result;
            await _userManager.UpdateAsync(user);

            return new Response<string>
            {
                StatusCode = 200,
                Succeeded = true,
                Errors = null,
                Message = "Picture changed",
                Data = null
            };
        }

        public async Task<Response<string>> DeleteUser(string id, string password)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) throw new BadRequestException("User does not exist", new FluentValidation.Results.ValidationResult());
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (!result.Succeeded) throw new BadRequestException("Incorrect password", new FluentValidation.Results.ValidationResult());
            await _userManager.DeleteAsync(user);

            return new Response<string>
            {
                StatusCode = 200,
                Succeeded = true,
                Errors = null,
                Message = "Account deleted",
                Data = null
            };
        }

        public async Task<Response<string>> ChangeUsersData(string id, ChangeUsersDataRequest request)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) throw new BadRequestException("User does not exist", new FluentValidation.Results.ValidationResult());

            user.Email = request.Email != "" ? request.Email : user.Email;
            user.PhoneNumber = request.PhoneNumber != "" ? request.PhoneNumber : user.PhoneNumber;
            user.FullName = request.FullName != "" ? request.FullName : user.FullName;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded) throw new BadRequestException("New data is invalid", new FluentValidation.Results.ValidationResult());

            return new Response<string>
            {
                StatusCode = 200,
                Succeeded = true,
                Errors = null,
                Message = "Account updated",
                Data = null
            };
        }

    }
}
