using Solicitudes.Data;
using Solicitudes.Services;
using Microsoft.EntityFrameworkCore;



using Serilog;
using Serilog.Events;

using Solicitudes.Filters;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();

// Agregar servicio
builder.Services.AddWindowsService();
builder.Services.AddScoped<LogActionFilter>();
builder.Services.AddScoped<LogActionFilterAsync>();

var logDirectory = "/logs/solicitudes";
var logFilePath = Path.Combine(logDirectory, "SolicitudesLog.txt");

if (!Directory.Exists(logDirectory))
{
    Directory.CreateDirectory(logDirectory);
}

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Logging.AddSerilog();
// builder.Services.AddHostedService<ServiceA>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ClienteContext>(options =>
{
  var connectionString = builder.Configuration.GetConnectionString("WebApiDatabase");
  var host = Environment.GetEnvironmentVariable("HOST");
  connectionString = connectionString.Replace("__HOST__", host);
  options.UseNpgsql(connectionString);
});

// Agregar los servicios
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<SolicitudService>();
builder.Services.AddScoped<PagoService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//   app.UseSwagger();
//   app.UseSwaggerUI();
// }
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.CreateDbIfNotExists();
app.Run();


app.DisposeLogAndStopSerilog();

public static class ApplicationExtensions
{
    public static void DisposeLogAndStopSerilog(this IApplicationBuilder app)
    {
        var lifetime = app.ApplicationServices.GetService<IHostApplicationLifetime>();
        lifetime.ApplicationStopped.Register(Log.CloseAndFlush);
    }
}
