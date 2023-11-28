using APi.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;

services.AddSwaggerGen();
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

var connectrionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};TrustServerCertificate=true";

services.AddDbContext<MovieContext>(
    option => option.UseSqlServer(connectrionString));

services.AddAutoMapper(Assembly.GetExecutingAssembly());

services.AddControllers();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi Api V1");
    });

}

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();


app.Run();

