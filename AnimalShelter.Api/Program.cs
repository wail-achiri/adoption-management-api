using System.Text.Json.Serialization;
using AnimalShelter.Api.Data;
using AnimalShelter.Api.Models.Enums;
using AnimalShelter.Api.Repositories;
using AnimalShelter.Api.Repositories.Interfaces;
using AnimalShelter.Api.Services;
using AnimalShelter.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<AnimalShelterDbContext>(opt =>
    opt.UseNpgsql(
        connectionString,
        o =>
        {
            o.MapEnum<AdoptionState>("adoption_state");
            o.MapEnum<AnimalState>("animal_state");
            o.MapEnum<AnimalType>("animal_type");
            o.MapEnum<UserRol>("user_rol");
            o.MapEnum<UserState>("user_state");
        }));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter()
        );
    });

builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) 
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
