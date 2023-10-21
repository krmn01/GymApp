﻿using GymApp.Application.Interfaces.Persistence;
using GymApp.Persistence.DatabaseContext;
using GymApp.Persistence.Repositories;
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
            //services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IPersonalTrainerRepository,PersonalTrainerRepository>();
            services.AddScoped<IClassRepository,ClassRepository>();

            return services;
        }
    }
}
