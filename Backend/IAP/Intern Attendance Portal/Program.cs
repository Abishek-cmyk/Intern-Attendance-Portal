using IAP.Application.Common;
using IAP.Domain.Data;
using Microsoft.EntityFrameworkCore;
using IAP.Domain.Interface;
using IAP.Domain.Repository;
using IAP.Application.Services;
using IAP.Domain.Interfaces;
using IAP.Application.DTOs.SystemSetting;
using IAP.Domain.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Configure CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy("customPolicy", x =>
        x.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());
});

#endregion

#region Configure Database

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString,
        b => b.MigrationsAssembly("IAP.API")));

#endregion

#region Configure Mapping

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

#endregion

#region Config Repos
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddTransient<ISettingRepository, SettingRepository>();

#endregion

#region Config Services
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<AttendanceService>();
builder.Services.AddScoped<SettingService>();
#endregion

#region Config Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("customPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();