using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Interfaces.Identity
{
    public interface IJwtHelper
    {
        string GetIdFromToken(string token);
    }
}
