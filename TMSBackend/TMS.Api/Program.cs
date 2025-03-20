using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TMS.Data.Context;
using TMS.Data.Interfaces;
using TMS.Data.Map;
using TMS.Data.Repositories;
using TMS.Data.Services;
using TMS.Data.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"])),
        ValidateIssuer = false,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
    };
});

// Registering services for dependency injection

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductionService, ProductionService>();
builder.Services.AddScoped<IBusinessUnitService,BusinessUnitService>();
builder.Services.AddScoped<ISupervisorService, SupervisorService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductionRecordRepository, ProductionRecordRepository>();
builder.Services.AddScoped<ITyreProductionRepository,TyreProductionRepository>();
builder.Services.AddScoped<ITyreSalesRepository,TyreSalesRepository>();
builder.Services.AddScoped<ILogRepository, LogRepository>();




builder.Services.AddAutoMapper(typeof(MappingProfile));




builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


builder.Services.AddDbContext<TMSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TMSContext")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"));
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
