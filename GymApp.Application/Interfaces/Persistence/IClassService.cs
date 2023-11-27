using GymApp.Application.Features.Class;
using GymApp.Application.Features.Class.Commands.AddClass;
using GymApp.Application.Features.Class.Commands.UpdateClass;
using GymApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Interfaces.Persistence
{
    public interface IClassService
    {
        Task<Response<string>> AssignUserToClassAsync(Guid UserId, Guid ClassId);
        Task<Response<string>> UnassignClassFromUserAsync(Guid UserId, Guid ClassId);
        Task<Response<List<ClassDTO>>> GetUsersClassesAsync(Guid ProfileId);
        Task<Response<string>> AddNewClassAsync(AddClassDTO Class);
        Task<Response<string>> UpdateClassAsync(string id, UpdateClassDTO Class);
        Task<Response<string>> DeleteClassAsync(string classId);
    }
}
