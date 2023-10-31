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
    public class PersonalTrainerRepository : GenericRepository<PersonalTrainer>, IPersonalTrainerRepository
    {
        public PersonalTrainerRepository(GymDatabaseContext context) : base(context)
        {
        }

        public override async Task<List<PersonalTrainer>> GetAllAsync() 
        {
            return await _context.Set<PersonalTrainer>().Include(p => p.Classes).AsNoTracking().ToListAsync();
        }

    }
}
