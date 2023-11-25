using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Interfaces.Helpers
{
    public static class ValidationHelper
    {
        public static string ValidationErrorsToString(List<ValidationFailure> errors)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var error in errors) sb.Append($"{error.ErrorMessage} ,");
            return sb.ToString();
        }
    }
}
