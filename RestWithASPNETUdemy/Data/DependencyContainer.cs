using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Services;
using RestWithASPNETUdemy.Services.Implementations;

namespace RestWithASPNETUdemy.Data;

public class DependencyContainer
{    
   
    public static void RegisterServices(WebApplicationBuilder builder)
    {
        var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
        builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 27))));
        builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();
    }
}