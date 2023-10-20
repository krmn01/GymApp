using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.ApplicationUser.Queries.GetUsersData
{
    public class ApplicationUserDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set;} = string.Empty;
    }
}
