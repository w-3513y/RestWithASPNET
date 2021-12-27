using RestWithASPNETUdemy.Data;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration().
                 WriteTo.Console().CreateLogger();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning();
DependencyContainer.RegisterServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //swagger
    app.UseSwagger();
    app.UseSwaggerUI();

    //migrations
    try
    {
var evolve = new Evolve.Evolve(new 
       Pomelo.EntityFrameworkCore.MySql.Data.MySqlClient.MySqlConnection())
    }
    catch (Exception e)
    {
        Log.Error("Database migration failed", e);
        throw;
    }
}

//app.UseHttpsRedirection();e

app.UseAuthorization();

app.MapControllers();

app.Run();
