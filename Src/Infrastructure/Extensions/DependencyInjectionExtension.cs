using Application.Services;
using Domain.Entities;
using Domin.Entities;
using Infrastructure.Data;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class DependencyInjectionExtension
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
            services.AddScoped<IRepository<Admin>, AdminRepo>();
            services.AddScoped<IRepository<Manager>, ManagerRepo>();
            services.AddScoped<IRepository<Tenant>, TenantRepo>();
            services.AddScoped<IRepository<User>, UserRepo>();
            services.AddScoped<IRepository<Contact>, ContactRepo>();

            services.AddScoped<ClsPeople>();


            return services;
        }
    }
}
