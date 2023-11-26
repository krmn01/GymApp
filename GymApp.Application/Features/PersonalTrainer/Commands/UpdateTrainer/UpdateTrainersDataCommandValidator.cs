using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.PersonalTrainer.Commands.UpdateTrainer
{
    public class UpdateTrainersDataCommandValidator :AbstractValidator<UpdateTrainersDataCommand>
    {
        public UpdateTrainersDataCommandValidator()
        {
            RuleFor(x => x.TrainerGuid).NotNull().NotEmpty().WithMessage("Trainers id cannot be null");
            
            RuleFor(x => x.UpdatedTrainer.PhoneNumber)
                .Null()
                .When(x => x.UpdatedTrainer.PhoneNumber == null) 
                .NotEmpty()
                .When(x => x.UpdatedTrainer.PhoneNumber != null)
                .Matches(@"^\d{9}$")
                .When(x => x.UpdatedTrainer.PhoneNumber != null) 
                .WithMessage("Phone number must be a 9-digit number");

            RuleFor(x => x.UpdatedTrainer.Name)
                .Null()
                .When(x => x.UpdatedTrainer.Name == null) 
                .NotEmpty()
                .When(x => x.UpdatedTrainer.Name != null) 
                .MinimumLength(3)
                .When(x => x.UpdatedTrainer.Name != null) 
                .MaximumLength(30)
                .When(x => x.UpdatedTrainer.Name != null) 
                .Must(name => char.IsUpper(name.FirstOrDefault()))
                .When(x => x.UpdatedTrainer.Name != null) 
                .WithMessage("Name must start with an uppercase letter and be between 3 and 30 characters");

            RuleFor(x => x.UpdatedTrainer.Email)
                .Null()
                .When(x => x.UpdatedTrainer.Email == null)
                .EmailAddress()
                .When(x => x.UpdatedTrainer.Email != null)
                .WithMessage("Invalid email address");

            RuleFor(x => x.UpdatedTrainer.Surname)
               .Null()
               .When(x => x.UpdatedTrainer.Surname == null)
               .NotEmpty()
               .When(x => x.UpdatedTrainer.Surname != null)
               .MinimumLength(3)
               .When(x => x.UpdatedTrainer.Surname != null)
               .MaximumLength(30)
               .When(x => x.UpdatedTrainer.Surname != null)
               .Must(name => char.IsUpper(name.FirstOrDefault()))
               .When(x => x.UpdatedTrainer.Surname != null)
               .WithMessage("Surname must start with an uppercase letter and be between 3 and 30 characters");
        }
    }
}
