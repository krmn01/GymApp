using GymApp.Application.Interfaces.Persistence;
using GymApp.Domain.Entities;
using GymApp.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Persistence.Repositories
{
    public class ClassUsersProfileRepository : GenericRepository<ClassUsersProfile>, IClassUsersProfileRepository
    {
        public ClassUsersProfileRepository(GymDatabaseContext context) : base(context)
        {
        }
    }
}
