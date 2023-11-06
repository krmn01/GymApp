using GymApp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Domain.Entities
{
    [Keyless]
    public class ClassUsersProfile
    {
        public Guid ClassesId { get; set; }
        public Guid UsersId { get; set; }
        public UsersProfile UsersProfile { get; set; }
        public Class Class { get; set; }

    }
}
