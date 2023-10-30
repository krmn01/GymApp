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
    public class TrainingGoalRepository : GenericRepository<TrainingGoal>, ITrainingGoalsRepository
    {
        public TrainingGoalRepository(GymDatabaseContext context) : base(context)
        {
        }

        public async Task<List<TrainingGoal>> GetTrainingGoalsByProfileId(Guid ProfileId)
        {
            return await _context.Set<TrainingGoal>().Where(x => x.Profile.Id == ProfileId).AsNoTracking().ToListAsync();
        }
    }
}
