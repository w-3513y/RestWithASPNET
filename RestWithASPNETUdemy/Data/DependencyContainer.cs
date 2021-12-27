using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Data.Context;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Interfaces.Business;
using RestWithASPNETUdemy.Interfaces.Repository;
using RestWithASPNETUdemy.Repository;

namespace RestWithASPNETUdemy.Data;

public class DependencyContainer
{    
   
    public static void RegisterServices(WebApplicationBuilder builder)
    {
        //Context
        var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
        builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 27))));
        //Services
        builder.Services.AddScoped<IPersonBusiness, PersonBusiness>();
        //Repository
        builder.Services.AddScoped<IPersonRepository, PersonRepository>();
    }
}