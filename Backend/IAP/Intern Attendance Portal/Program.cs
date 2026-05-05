using IAP.Application;
using IAP.Domain.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<Class1>();


// Add services to the container.
#region Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("customPolicy", x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

#endregion


#region Configure Database

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString,
    b => b.MigrationsAssembly("IAP.API")
    ));


#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors("customPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
