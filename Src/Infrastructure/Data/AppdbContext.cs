using Infrastructure.Data.Configurations;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Infrastructure.Data
{
    internal class AppdbContext: DbContext
    {

        
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Contact> Contacts { get; set; }



        public AppdbContext(DbContextOptions<AppdbContext> options) : base(options) {}

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // Remove the overhead of Index Foreign Key columns
            // Leave set them explicitly
            configurationBuilder.Conventions.Remove(typeof(ForeignKeyAttributeConvention));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Reduce writing the code to configure Entities by separation of concerns 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonConfiguration).Assembly);
        }
    }
}
