using FluentValidation;
using GymApp.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.ApplicationUser.Commands.CreateUser
{
    public class CreateUserCommandValidator :AbstractValidator<CreateUserCommand>
    {
       /// private readonly IUserRepository _userRepository;
        //private async Task<bool> UserNameUnique(CreateUserCommand command, CancellationToken cancellationToken)
        //{
        //    return await _userRepository.IsUserNameUnique(command.UserName);
        //}
        //public CreateUserCommandValidator(IUserRepository userRepository)
        //{
        //    _userRepository = userRepository;

        //    RuleFor(x => x.FullName)
        //        .NotEmpty().WithMessage("FullName cannot be empty")
        //        .NotNull()
        //        .MaximumLength(40).WithMessage("FullName maximum length is 40 characters");

        //    RuleFor(x => x.Password)
        //        .NotEmpty().WithMessage("Password cannot be empty")
        //        .NotNull()
        //        .Equal(x => x.ConfirmPassword).WithMessage("Passwords are not the same");

        //    RuleFor(x => x)
        //        .MustAsync(UserNameUnique)
        //        .WithMessage("Username already exists");
        //}
    }
}
