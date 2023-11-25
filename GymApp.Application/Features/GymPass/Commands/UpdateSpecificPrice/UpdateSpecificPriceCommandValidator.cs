using FluentValidation;
using GymApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.GymPass.Commands.UpdateSpecificPrice
{
    public class UpdateSpecificPriceCommandValidator :AbstractValidator<UpdateSpecificPriceCommand>
    {
        public UpdateSpecificPriceCommandValidator()
        {
            RuleFor(x => x.GymPassPriceDTO.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
