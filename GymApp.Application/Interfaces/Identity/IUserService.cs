using GymApp.Application.Models.Identity;
using GymApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Interfaces.Identity
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<GetUserResponse> GetUserById(string id);
    }
}
