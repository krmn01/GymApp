using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.PersonalTrainer.Commands.CreateNewTrainer
{
    public class CreateNewTrainerCommandValidator :AbstractValidator<CreateNewTrainerCommand>
    {
        public CreateNewTrainerCommandValidator()
        {
            RuleFor(x => x.NewTrainer.Email)
                .NotNull()
                .EmailAddress()
                .WithMessage("Email address is incorrect");

            RuleFor(x => x.NewTrainer.PhoneNumber)
                .NotNull()
                .Matches(@"^\d{9}$")
                .WithMessage("Phone number must be a 9-digit number");
            
            RuleFor(x => x.NewTrainer.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(30)
                .Must(name => char.IsUpper(name.FirstOrDefault()))
                .WithMessage("Name is invalid");

            RuleFor(x => x.NewTrainer.Surname)
               .NotNull()
               .NotEmpty()
               .MinimumLength(3)
               .MaximumLength(30)
               .Must(name => char.IsUpper(name.FirstOrDefault()))
               .WithMessage("Surname is invalid");
        }

    }
}
