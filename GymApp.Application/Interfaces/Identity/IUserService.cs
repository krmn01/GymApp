using GymApp.Application.Models.Identity;
using GymApp.Domain.Common;
using MediatR;
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
        Task<Response<string>> UpdatePasswordAsync(string id, UpdatePasswordRequest request);
        Task<Response<string>> UpdateProfilePicture(string id, byte[] picture);

        Task<Response<string>> DeleteUser(string id, string password);

        Task<Response<string>> ChangeUsersData(string id, ChangeUsersDataRequest request);
    }
}
