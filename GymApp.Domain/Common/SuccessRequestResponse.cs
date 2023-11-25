using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Domain.Common
{
    public class SuccessRequestResponse<T> :Response<T> where T : class
    {
        //int code, bool success, string message = null, string errors = null, T data = null
        public SuccessRequestResponse(string message = null,T data = null)
        {
            StatusCode = 200;
            Succeeded = true;
            Data = data;
            Message = message;
        }
    }
}
