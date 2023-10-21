using GymApp.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Identity.DatabaseContext
{
    public class GymIdentityDatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public GymIdentityDatabaseContext(DbContextOptions<GymIdentityDatabaseContext>options) :base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(GymIdentityDatabaseContext).Assembly);
        }
    }
}
