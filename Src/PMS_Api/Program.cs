using Infrastructure.Extensions;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        if (connectionString == null) throw new InvalidDataException(nameof(connectionString) + " is invalid :(");
        
        builder.Services.AddDependencyGroup_Infrastructure(connectionString);
        builder.Services.AddControllers();

        var app = builder.Build();


        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.MapControllers();

        app.Run();
    }
}