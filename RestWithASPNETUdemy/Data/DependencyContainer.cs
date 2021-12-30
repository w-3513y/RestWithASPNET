using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Data.Context;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Interfaces.Business;
using RestWithASPNETUdemy.Interfaces.Repository;
using RestWithASPNETUdemy.Repository;
using Serilog;
using MySqlConnector;

namespace RestWithASPNETUdemy.Data;

public class DependencyContainer
{

    public static void RegisterServices(WebApplicationBuilder builder, IWebHostEnvironment environment)
    {
        //Context
        var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
        //Migrations
        if (environment.IsDevelopment())
        {
            MigrateDataBase(connection);
        }
        builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 27))));
        //Services
        builder.Services.AddScoped<IPersonBusiness, PersonBusiness>();
        //Repository
        builder.Services.AddScoped<IPersonRepository, PersonRepository>();

    }

    private static void MigrateDataBase(string connection)
    {
        Log.Logger = new LoggerConfiguration().
         WriteTo.Console().CreateLogger();

        try
        {
            MySqlConnection evolveConnection = new(connection);
            var evolve = new Evolve.
                Evolve(evolveConnection, msg =>
                Log.Information(msg))
            {
                Locations = new List<string>
                {
                    "db/migrations", 
                    "db/dataset"
                },
                IsEraseDisabled = true
            };
            evolve.Migrate();

        }
        catch (Exception e)
        {
            Log.Error("Database migration failed", e);
            throw;
        }
    }
}