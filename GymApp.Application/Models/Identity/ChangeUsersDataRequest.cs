﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Models.Identity
{
    public class ChangeUsersDataRequest
    {
        public string? PhoneNumber { get; set; }
        public string? FullName { get; set;}
        public string? Email { get; set; }
    }
}
