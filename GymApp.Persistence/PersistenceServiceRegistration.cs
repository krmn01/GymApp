using GymApp.Application.Interfaces.Persistence;
using GymApp.Persistence.DatabaseContext;
using GymApp.Persistence.Repositories;
using GymApp.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GymDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MssqlConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IPersonalTrainerRepository,PersonalTrainerRepository>();
            services.AddScoped<IClassRepository,ClassRepository>();
            services.AddScoped<IProfilePictureRepository, ProfilePictureRepository>();
            services.AddScoped<IUsersProfileRepository, UsersProfileRepository>();
            services.AddScoped<ITrainingGoalsRepository, TrainingGoalRepository>();
            services.AddScoped<ITrainingGoalService, TrainingGoalService>();
            services.AddScoped<IPersonalTrainerService, PersonalTrainerService>();
            services.AddScoped<IGymPassRepository, GymPassRepository>();
            services.AddScoped<IGymEntryRepository, GymEntryRepository>();
            services.AddScoped<IClassUsersProfileRepository, ClassUsersProfileRepository>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IQrService, QrService>();
            services.AddScoped<IGymPassService, GymPassService>();
            services.AddScoped<IGymEntryService, GymEntryService>();

            return services;
        }
    }
}
