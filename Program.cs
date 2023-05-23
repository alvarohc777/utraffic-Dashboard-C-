using Solicitudes.Data;
using Solicitudes.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlite<ClienteContext>("Data Source=Solicitudes.db");
// builder.Services.AddSqlite<ClienteContext>("Data Source=Solicitudes.db;Foreign Keys=True;");

// Agregar los servicios
builder.Services.AddScoped<ClienteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.CreateDbIfNotExists();
app.Run();
