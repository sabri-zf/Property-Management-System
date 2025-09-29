using Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Domain.Entities;
using Domain.Entities.Entities_Views;
using Domin.Entities;

namespace Infrastructure.Data
{
    public sealed class AppdbContext: DbContext
    {

        
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<AdminView> AdminViews { get; set; }
        public DbSet<ManagerView> ManagerViews { get; set; }
        public DbSet<TenantView> TenantViews { get; set; }
        public DbSet<ContactView> ContactViews { get; set; }
        public DbSet<PersonView> personViews { get; set; }
        public DbSet<UserView> UserViews { get; set; }



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

            modelBuilder.Entity<AdminView>().ToView("AdminDetailsView");
            modelBuilder.Entity<ManagerView>().ToView("ManagerDetailsView");
            modelBuilder.Entity<TenantView>().ToView("TeanatDetailsView");
            modelBuilder.Entity<ContactView>().ToView("ContactDetailsView");
            modelBuilder.Entity<PersonView>().ToView("PeopleDetailsView");
            modelBuilder.Entity<UserView>().ToView("UsersDetailsView");

        }
    }
}
