using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Exceptions
{
    public class BadRequestException :Exception
    {
        public BadRequestException(string message) :base($"[{DateTime.Now.ToString("HH:mm:ss")}] {message}")
        {
            
        }
    }
}
