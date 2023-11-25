using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.GymPass.Commands.RenewGymPass
{
    public class RenewGymPassCommandValidator :AbstractValidator<RenewGymPassCommand>
    {
        public RenewGymPassCommandValidator()
        {
            RuleFor(x => x.ProfileId).NotNull().NotEmpty().WithMessage("Profile id cannot be empty");
            RuleFor(x => x.NumberOfDays).GreaterThan(0).WithMessage("Number of days must be greater than 0");
        }
    }
}
