﻿using GymApp.Application.Interfaces.Persistence;
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
    public class UsersProfileRepository : GenericRepository<UsersProfile>, IUsersProfileRepository
    {
        public UsersProfileRepository(GymDatabaseContext context) : base(context)
        {
        }

    }
}
