using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Entities;
using GymApp.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Persistence.Repositories
{
    public class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        public ClassRepository(GymDatabaseContext context) : base(context)
        {
        }

        public async Task<List<Class>> GetAllUsersClasses(Guid ProfileId)
        {
            var classes = await _context.Set<Class>().Include(a => a.Users).AsNoTracking().ToListAsync();
            List<Class> usersClasses = new List<Class>();

            foreach (var @class in classes)
                foreach (var user in @class.Users)
                    if (user.Id == ProfileId) usersClasses.Add(@class);

            return usersClasses;
        }
    }
}
