using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.Class.Commands.UpdateClass
{
    public class UpdateClassCommandValidator :AbstractValidator<UpdateClassCommand>
    {
        public UpdateClassCommandValidator()
        {
            RuleFor(x => x.UpdatedClass.ClassName)
                .Null()
                .When(x => x.UpdatedClass.ClassName == null)
                .NotEmpty()
                .When(x => x.UpdatedClass.ClassName != null)
                .MinimumLength(3)
                .When(x => x.UpdatedClass.ClassName != null)
                .WithMessage("Class name must be longer than 3 characters");

            RuleFor(x => x.UpdatedClass.StartTime)
                .Null()
                .When(x => x.UpdatedClass.StartTime == null)
                .NotEmpty()
                .When(x => x.UpdatedClass.StartTime != null)
                .LessThan(x => x.UpdatedClass.EndTime)
                .When(x => x.UpdatedClass.StartTime != null && x.UpdatedClass.EndTime != null)
                .WithMessage("End time must be greater than start time");

            RuleFor(x => x.UpdatedClass.EndTime)
              .Null()
              .When(x => x.UpdatedClass.EndTime == null)
              .NotEmpty()
              .When(x => x.UpdatedClass.EndTime != null)
              .GreaterThan(x => x.UpdatedClass.StartTime)
              .When(x => x.UpdatedClass.StartTime != null && x.UpdatedClass.EndTime != null)
              .WithMessage("End time must be greater than start time");

            RuleFor(x => x.UpdatedClass.DayOfWeek)
                .Null()
                .When(x => x.UpdatedClass.DayOfWeek == null)
                .NotEmpty()
                .When(x => x.UpdatedClass.DayOfWeek != null)
                .WithMessage("Day of week should be entered properly");
            
            RuleFor(x => x.UpdatedClass.TrainerId)
                .Null()
                .When(x => x.UpdatedClass.TrainerId == null)
                .NotEmpty()
                .When(x => x.UpdatedClass.TrainerId != null)
                .WithMessage("Trainer id should be entered properly");

            RuleFor(x => x.UpdatedClass.MaxUsers)
                .Null()
                .When(x => x.UpdatedClass.MaxUsers == null)
                .InclusiveBetween(1, 50)
                .When(x => x.UpdatedClass.MaxUsers != null)
                .WithMessage("Max users count must be greater than 0 and fewer than 50");
        }
    }
}
