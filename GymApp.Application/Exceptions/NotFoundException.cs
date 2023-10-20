using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Exceptions
{
    public class NotFoundException :Exception
    {
        public NotFoundException(object key,string name) 
            : base($"[{DateTime.Now.ToString("HH:mm:ss")}] {name} {key} was not found.")         
        {
            
        }
    }
}
