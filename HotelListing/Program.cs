using HotelListing;
using HotelListing.Configurations;
using HotelListing.Data;
using HotelListing.IRepository;
using HotelListing.Repository;
using HotelListing.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
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
var connectionString = builder.Configuration.GetConnectionString("sqlConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers(config=>
{
    config.CacheProfiles.Add("120SecondsDuration", new CacheProfile
    {
        Duration = 120
    });
});
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.AddScoped<IAuthManager,AuthManager>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.ConficureJWt(builder.Configuration);
builder.Services.AddResponseCaching();
builder.Services.AddCors(o => {
    o.AddPolicy("CorsPolicy", builder => {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
        });

});
builder.Services.AddAutoMapper(typeof(MapperInitializer));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.ConfigureVersioning();
AddSwaggerDoc(builder.Services);

void AddSwaggerDoc(IServiceCollection services)
{
    builder.Services.AddSwaggerGen(c =>
    {
        c.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme
        {
            Description =@"JWT Authorization header using the Bearer scheme.
                     Enter 'Bearer' [space] and then your token in the text input below.
                     Example:'Bearer 12345asdfgf'",
            Name ="Authorization",
            In=ParameterLocation.Header,
            Type =SecuritySchemeType.ApiKey,
            Scheme ="Bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference =new OpenApiReference
                    {
                        Type =ReferenceType.SecurityScheme,
                        Id="Bearer"
                    },
                    Scheme ="0auth2",
                    Name="Bearer",
                    In=ParameterLocation.Header, 
                },
                new List<string>()
            }
        });
        c.SwaggerDoc("v1",new OpenApiInfo { Title="HotelListing",Version="v1"});
    });
}

builder.Services.AddControllers().AddNewtonsoftJson(op=>
op.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(connectionString );
});


var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseSwagger();
app.UseSwaggerUI();
app.ConfigureExceptionHandler();
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseResponseCaching();
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

