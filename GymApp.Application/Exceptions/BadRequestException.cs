using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Exceptions
{
    public class BadRequestException :Exception
    {
        private List<string> _errors;
        public BadRequestException(string message,ValidationResult validationResult) :base($"[{DateTime.Now.ToString("HH:mm:ss")}] {message}")
        {
            _errors = new();
            foreach(var error in validationResult.Errors)
            {
                _errors.Add(error.ErrorMessage);
            }
        }
    }
}
