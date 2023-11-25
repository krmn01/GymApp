using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Domain.Common
{
    public class Response<T> where T : class
    {
        public int StatusCode { get; set; }
        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public string? Errors { get; set; }
        public T? Data { get; set; }
    }
}
