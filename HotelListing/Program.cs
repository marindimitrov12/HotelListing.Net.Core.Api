using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File(
    path: "c:\\hotellistings\\logs\\log-.txt",
    outputTemplate:"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}[{Level:u3}]{Message:lj}{NewLine}{Exception}",
    rollingInterval:RollingInterval.Day,
    restrictedToMinimumLevel:LogEventLevel.Information
    ).CreateLogger();
  

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title="HotelListing", Version = "v1" });
});


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
try
{
    Log.Information("Aplication is starting");
    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex,"Application Failed to start");
}
finally
{
    Log.CloseAndFlush();
}

