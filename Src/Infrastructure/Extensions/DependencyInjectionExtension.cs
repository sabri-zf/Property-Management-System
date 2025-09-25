using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    internal static class DependencyInjectionExtension
    {



        public static IServiceCollection AddConfig(this IServiceCollection services)
        {
            var connectionStr = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .Build()
                                    .GetSection("connectionString");

            services.AddDbContext<AppdbContext>(option =>
            {
                option.UseSqlServer(connectionStr.Value);
            });

            return services;
        }

        public static IServiceCollection AddDependencyGroup_Infrastructure(this IServiceCollection services)
        {
            //One instance per scope
            //so all repositories in one request share the same database context
            services.AddScoped<IRepository<Person>, PeopleRepo>();


            return services;
        }
    }
}
