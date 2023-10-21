using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Entities;
using GymApp.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Persistence.Repositories
{
    //public class UserRepository :GenericRepository<ApplicationUser>,IUserRepository
    //{
    //    public UserRepository(GymDatabaseContext context) : base(context)
    //    {
    //    }

    //    public async Task<bool> IsUserNameUnique(string username)
    //    {
    //        return await _context.Users.AnyAsync(u => u.UserName == username);
    //    }

    //}
}
