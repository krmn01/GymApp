using GymApp.Application.Exceptions;
using GymApp.Application.Features.ProfilePicture.Queries.GetPicture;
using GymApp.Application.Features.UsersProfile;
using GymApp.Application.Interfaces.Identity;
using GymApp.Application.Models.Identity;
using GymApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.UnitTests.Mocks
{
    public class MockUserService
    {
        public static Mock<IUserService> UserServiceMock()
        {

            var mock = new Mock<IUserService>();
            mock.Setup(r => r.GetUserById(It.IsAny<string>())).Returns((string id) =>
            {
                if (id != "00000000-0000-0000-0000-000000000001") return Task.FromResult(new GetUserResponse{Succeeded = false});
                
                var response = new GetUserResponse
                {
                    Succeeded = true,
                    Data = new ProfileDTO
                    {
                        ProfilePicture = null,
                        User = new User
                        {
                            UserName = "Test",
                            Email = "Test",
                            FullName = "Test",
                            Id = "00000000-0000-0000-0000-000000000001"
                        }
                    }
                };
                return Task.FromResult(response);
            });

            return mock;
        }
    }
}
