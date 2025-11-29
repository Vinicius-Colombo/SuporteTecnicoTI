using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuporteTI.API.Services;
using SuporteTI.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados
builder.Services.AddDbContext<SuporteTiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IEmailService, EmailService>();

// Registrar outros serviços
builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddScoped<SuporteTI.API.Services.IAService>();

// Add services to the container
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilita Swagger sempre
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
