using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuporteTI.API.Services;
using SuporteTI.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados
builder.Services.AddDbContext<SuporteTiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddScoped<SuporteTI.API.Services.IAService>();

var app = builder.Build();

// Habilita Swagger sempre
app.UseSwagger();
app.UseSwaggerUI();

// Impede execução local
if (app.Environment.IsDevelopment())
{
    throw new Exception("Esta API só pode ser executada na Azure.");
}

//app.UseHttpsRedirection();

app.MapControllers();

app.Run();

