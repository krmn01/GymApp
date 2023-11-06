using GymApp.Domain.Common;
using GymApp.Domain.Entities;
using GymApp.Persistence.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Persistence.DatabaseContext
{
    public class GymDatabaseContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<PersonalTrainer> PersonalTrainers { get; set; }
        public DbSet<ProfilePicture> ProfilePictures { get; set; }
        public DbSet<UsersProfile> UsersProfiles { get; set; }
        public DbSet<TrainingGoal> TrainingGoals { get; set; }
        public DbSet<GymPass> GymPasses { get; set; }
        public DbSet<GymEntry> GymEntries { get; set; }

        public DbSet<Class> ClassUsersProfiles { get; set; }


        public GymDatabaseContext(DbContextOptions<GymDatabaseContext> options) :base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GymDatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entity in base.ChangeTracker.Entries<BaseEntity>()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
            {
                entity.Entity.UpdatedOn = DateTime.Now;
                if(entity.State == EntityState.Added) entity.Entity.CreatedOn = DateTime.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
