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
    public class ProfilePictureRepository : GenericRepository<ProfilePicture>, IProfilePictureRepository
    {
        public ProfilePictureRepository(GymDatabaseContext context) : base(context)
        {
        }
    }
}
