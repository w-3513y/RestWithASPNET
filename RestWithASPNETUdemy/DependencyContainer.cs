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
using RestWithASPNETUdemy.Entities;
using RestWithASPNETUdemy.Hypermedia.Filters;
using RestWithASPNETUdemy.Hypermedia.Enricher;
using Microsoft.Net.Http.Headers;
using RestWithASPNETUdemy.Services;
using RestWithASPNETUdemy.Services.Implementations;
using RestWithASPNETUdemy.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

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
        builder.Services.AddScoped<ILoginBusiness, LoginBusiness>();
        builder.Services.AddTransient<ITokenService, TokenService>();
        //Repository
        builder.Services.AddScoped<IBaseRepository<Person>, BaseRepository<Person>>();
        builder.Services.AddScoped<IBaseRepository<Book>, BaseRepository<Book>>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        //Mapping
        builder.Services.AddScoped<IParser<PersonEntity, Person>, PersonConverter>();
        builder.Services.AddScoped<IParser<BookEntity, Book>, BookConverter>();
        //HATEOAS
        builder.Services.AddMvc(options =>
        {
            options.RespectBrowserAcceptHeader = true;
            options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
            options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
        }).AddXmlSerializerFormatters();

        var filterOptions = new HyperMediaFilterOptions();
        filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
        filterOptions.ContentResponseEnricherList.Add(new BookEnricher());
        builder.Services.AddSingleton(filterOptions);

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

    public static void Authentication(WebApplicationBuilder builder, TokenConfiguration tokenConfiguration)
    {
        builder.Services.AddSingleton(tokenConfiguration);
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = tokenConfiguration.Issuer,
                ValidAudience = tokenConfiguration.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Secret))
            };
        });
        builder.Services.AddAuthorization(auth =>
        {
            auth.AddPolicy("Bearar", new AuthorizationPolicyBuilder()
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                        .RequireAuthenticatedUser().Build());
        });
    }
}