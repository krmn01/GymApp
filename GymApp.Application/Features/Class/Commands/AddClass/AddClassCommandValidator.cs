using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.Class.Commands.AddClass
{
    public class AddClassCommandValidator :AbstractValidator<AddClassCommand>
    {
        public AddClassCommandValidator()
        {
            RuleFor(x => x.ClassDTO.ClassName).NotNull().NotEmpty().WithMessage("Class name cannot be null");
            RuleFor(x => x.ClassDTO.DayOfWeek).NotNull().NotEmpty().WithMessage("Day of week cannot be null");
            RuleFor(x => x.ClassDTO.TrainerId).NotNull().NotEmpty().WithMessage("Trainer id cannot be null");
            RuleFor(x => DateTime.Parse(x.ClassDTO.StartTime)).LessThan(x => DateTime.Parse(x.ClassDTO.EndTime)).WithMessage("End time must be greater than start time");
            RuleFor(x => x.ClassDTO.MaxUsers).NotNull().InclusiveBetween(1, 50).WithMessage("Max users count must be greater than 0 and fewer than 50");
        }
    }
}
