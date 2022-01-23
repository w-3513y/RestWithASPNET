using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Data.Context;
using RestWithASPNETUdemy.Services.Business;
using RestWithASPNETUdemy.Domain.Interfaces.Business;
using RestWithASPNETUdemy.Domain.Interfaces.Repository;
using Serilog;
using MySqlConnector;
using RestWithASPNETUdemy.Domain.Model;
using RestWithASPNETUdemy.Data.Repository;
using RestWithASPNETUdemy.Data.Mapping.Contract;
using RestWithASPNETUdemy.Data.Mapping.Implementations;
using RestWithASPNETUdemy.Domain.Entities;
using RestWithASPNETUdemy.Hypermedia.Filters;
using RestWithASPNETUdemy.Hypermedia.Enricher;
using Microsoft.Net.Http.Headers;
using RestWithASPNETUdemy.Services;
using RestWithASPNETUdemy.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using RestWithASPNETUdemy.Domain.Interfaces.Services;

namespace RestWithASPNETUdemy.Data;

public class DependencyContainer
{

    public static void RegisterServices(WebApplicationBuilder builder, string connection)
    {
        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        //Context
        builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 27))));
        //Services
        builder.Services.AddScoped<IPersonBusiness, PersonBusiness>();
        builder.Services.AddScoped<IBookBusiness, BookBusiness>();
        builder.Services.AddScoped<ILoginBusiness, LoginBusiness>();
        builder.Services.AddScoped<IFileBusiness, FileBusiness>();
        builder.Services.AddTransient<ITokenService, TokenService>();
        //Repository
        builder.Services.AddScoped<IBaseRepository<Person>, BaseRepository<Person>>();
        builder.Services.AddScoped<IBaseRepository<Book>, BaseRepository<Book>>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IPersonRepository, PersonRepository>();
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
            auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                        .RequireAuthenticatedUser().Build());
        });
    }
}