using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Domain.Common
{
    public class BadRequestResponse<T> :Response<T> where T : class
    {
        public BadRequestResponse(string errors){
            StatusCode = 400;
            Succeeded = false;
            Errors = errors;
        }
    }
}
