using FluentValidation;
using FluentValidation.Results;
using GymApp.Application.Features.Class;
using GymApp.Application.Features.Class.Commands;
using GymApp.Application.Features.Class.Commands.AddClass;
using GymApp.Application.Features.Class.Commands.UnassignClassFromUser;
using GymApp.Application.Features.Class.Queries.GetUsersClasses;
using GymApp.Application.Interfaces.Helpers;
using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Common;
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
            if (!validationResult.IsValid) return new Response<string>
            {
                StatusCode = 400,
                Succeeded = false,
                Message = null,
                Errors = ValidationHelper.ValidationErrorsToString(validationResult.Errors)
            };

            try
            {
                await _mediator.Send(request);
            }
            catch(Exception ex)
            {
                return new Response<string>
                {
                    StatusCode = 400,
                    Succeeded = false,
                    Message = null,
                    Errors = ex.Message
                };
            }

            return new Response<string>
            {
                StatusCode = 200,
                Succeeded = true,
                Errors = null,
                Message = "Class created",
                Data = null
            };
        }

        public async Task<Response<string>> AssignUserToClassAsync(Guid UserId, Guid ClassId)
        {
            var request = new AssignUserToClassCommand { UserProfileId = UserId, ClassId = ClassId };
            await _mediator.Send(request);

            return new Response<string>
            {
                StatusCode = 200,
                Succeeded = true,
                Errors = null,
                Message = "User successfully assigned to class",
                Data = null
            };
        }

        public async Task<Response<List<ClassDTO>>> GetUsersClassesAsync(Guid ProfileId)
        {
            var request = new GetUsersClassesQuery { ProfileId = ProfileId };
            var response = await _mediator.Send(request);
            return new Response<List<ClassDTO>>
            {
                StatusCode = 200,
                Succeeded = true,
                Errors = null,
                Data = response
            };
        }

        public async Task<Response<string>> UnassignClassFromUserAsync(Guid UserId, Guid ClassId)
        {
            var request = new UnassignClassFromUserCommand { ClassId = ClassId, ProfileId = UserId };
            await _mediator.Send(request);
            return new Response<string>
            {
                StatusCode = 200,
                Succeeded = true,
                Errors = null,
                Message = "User successfully unassigned from class"
            };
        }
    }
}
