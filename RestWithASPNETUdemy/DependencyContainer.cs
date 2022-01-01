using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Data.Context;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Interfaces.Business;
using RestWithASPNETUdemy.Interfaces.Repository;
using Serilog;
using MySqlConnector;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Data.Repository;
using RestWithASPNETUdemy.Data.Mapping.Contract;
using RestWithASPNETUdemy.Data.Mapping.Implementations;
using RestWithASPNETUdemy.Data.Entities;

namespace RestWithASPNETUdemy.Data;

public class DependencyContainer
{

    public static void RegisterServices(WebApplicationBuilder builder, string connection)
    {
        //Context
        builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 27))));
        //Services
        builder.Services.AddScoped<IPersonBusiness, PersonBusiness>();
        builder.Services.AddScoped<IBookBusiness, BookBusiness>();
        //Repository
        builder.Services.AddScoped<IBaseRepository<Person>, BaseRepository<Person>>();
        builder.Services.AddScoped<IBaseRepository<Book>, BaseRepository<Book>>();
        //Mapping
        builder.Services.AddScoped<IParser<PersonEntity, Person>, PersonConverter>();
        builder.Services.AddScoped<IParser<BookEntity, Book>, BookConverter>();
    }

    public static void CreateMigration(string connection)
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
                    "Data/migrations",
                    "Data/dataset"
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