using FluentValidation;
using FluentValidation.Results;
using GymApp.Application.Features.Class;
using GymApp.Application.Features.Class.Commands;
using GymApp.Application.Features.Class.Commands.AddClass;
using GymApp.Application.Features.Class.Commands.DeleteClass;
using GymApp.Application.Features.Class.Commands.UnassignClassFromUser;
using GymApp.Application.Features.Class.Queries.GetUsersClasses;
using GymApp.Application.Interfaces.Helpers;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Application.Models.Identity;
using GymApp.Domain.Common;
using GymApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Persistence.Services
{
    public class ClassService : IClassService
    {
        private readonly IMediator _mediator;
        public ClassService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Response<string>> AddNewClassAsync(AddClassDTO Class)
        {
            var request = new AddClassCommand { ClassDTO = Class };
            var validator = new AddClassCommandValidator();
            var validationResult = validator.Validate(request);
            
            if (!validationResult.IsValid) 
                return new BadRequestResponse<string>(ValidationHelper.ValidationErrorsToString(validationResult.Errors));

            try
            {
                await _mediator.Send(request);
            }
            catch(Exception ex)
            {
                return new BadRequestResponse<string>(ex.Message);
            }

            return new SuccessRequestResponse<string>("Class created");
        }

        public async Task<Response<string>> AssignUserToClassAsync(Guid UserId, Guid ClassId)
        {
            try
            {
                var request = new AssignUserToClassCommand { UserProfileId = UserId, ClassId = ClassId };
                await _mediator.Send(request);
            }catch(Exception ex)
            {
                return new BadRequestResponse<string>(ex.Message);
            }

            return new SuccessRequestResponse<string>("User successfully assigned to class");
        }

        public async Task<Response<string>> DeleteClassAsync(string classId)
        {
            try
            {
                var request = new DeleteClassCommand{ ClassId = Guid.Parse(classId) };
                await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                return new BadRequestResponse<string>(ex.Message);
            }

            return new SuccessRequestResponse<string>("Class deleted successfully");
        }

        public async Task<Response<List<ClassDTO>>> GetUsersClassesAsync(Guid ProfileId)
        {
            var request = new GetUsersClassesQuery { ProfileId = ProfileId };
            try
            {
                var response = await _mediator.Send(request);
                return new SuccessRequestResponse<List<ClassDTO>>(data: response);
            }catch(Exception ex)
            {
                return new BadRequestResponse<List<ClassDTO>>(ex.Message);
            }
        }

        public async Task<Response<string>> UnassignClassFromUserAsync(Guid UserId, Guid ClassId)
        {
            var request = new UnassignClassFromUserCommand { ClassId = ClassId, ProfileId = UserId };
            try
            {
                await _mediator.Send(request);
                return new SuccessRequestResponse<string>("User successfully unassigned from class");
            }catch(Exception ex)
            {
                return new BadRequestResponse<string>(ex.Message);
            }
        }
    }
}
