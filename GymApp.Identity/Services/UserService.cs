using GymApp.Application.Exceptions;
using GymApp.Application.Interfaces.Identity;
using GymApp.Application.Models.Identity;
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

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
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

        public async Task<User> GetUserById(string id)
        {
            var user = await _userManager.FindByNameAsync(id);
            if (user == null) throw new NotFoundException(id, typeof(User).ToString());
            return new User
            {
                Id = user.Id,
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
        }
    }
}
