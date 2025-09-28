using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data
{
    /*----------------------------------------------------------------------------------------------------------------
    // Aim of using Design Time Factory Interface 
    // 1 - To let migrations and other design-time commands
    //     run successfully, even if your application is not running.

    // It’s a special class you create in EF Core that tells the EF Core CLI tools (like dotnet ef migrations add)
    // how to build your DbContext at design time (outside your running application).

    // Pros:
    // Migrations always work, even without Presentation layer. ( when to bulid DI request)
    //  Lets you put migrations in Infrastructure without needing a startup project.
    // Keeps EF Core tooling independent of runtime DI.

    // When do we need it:
    // If you’re in N-tier / Clean Architecture and keep DbContext in Infrastructure.
    // If your Presentation project (Program.cs) is not ready yet.
    // If EF CLI cannot figure out how to create your DbContext automatically.
    ------------------------------------------------------------------------------------------------------------------*/


    internal class AppDbContextFactory : IDesignTimeDbContextFactory<AppdbContext>
    {
        public AppdbContext CreateDbContext(string[] args)
        {

            //prepare the connection from json file
            var connectionStr = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json",optional:false,reloadOnChange:true)
                                    .Build()
                                    .GetSection("connectionString");

            // option bulider Dbcontxt
            var OptionBulider = new DbContextOptionsBuilder<AppdbContext>()
                                     .UseSqlServer(connectionStr.Value);  


            return new AppdbContext(OptionBulider.Options);
        }
    }
}
