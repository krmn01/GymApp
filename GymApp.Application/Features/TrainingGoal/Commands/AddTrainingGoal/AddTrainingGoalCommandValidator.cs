using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.TrainingGoal.Commands.AddTrainingGoal
{
    public class AddTrainingGoalCommandValidator :AbstractValidator<AddTrainingGoalCommand>
    {
        public AddTrainingGoalCommandValidator()
        {
            RuleFor(x => x.ProfileId).NotNull().NotEmpty().WithMessage("Profile id cannot be empty");
            RuleFor(x => x.TrainingGoalDTO.Content)
                .MinimumLength(5)
                .MaximumLength(40)
                .WithMessage("Training goal content must be 5 to 40 characters length");
        }
    }
}
