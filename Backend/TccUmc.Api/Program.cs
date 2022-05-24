using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TccUmc.Api.JwtAuth;
using TccUmc.Api.Swagger;
using TccUmc.Domain.Models;
using TccUmc.Infrastructure.Database.Context;
using TccUmc.Ioc;
using TccUmc.Utility.Middleware;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;

service.AddControllers();
service.AddJwtAsymmetricAuthentication();
service.AddEndpointsApiExplorer();
service.AddSwaggerGen();
service
    .AddControllers()
    .AddJsonOptions(opts =>
    {
        var enumConverter = new JsonStringEnumConverter();
        opts.JsonSerializerOptions.Converters.Add(enumConverter);
    });

DependencyContainer.RegisterServices(service);
SwaggerServiceCollection.AddSwaggerServices(service);

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

try
{
    using var dbContext = new TccContext();
    dbContext.Database.Migrate();
    if (!dbContext.Clinics.Any())
    {
        dbContext.Clinics.Add(new Clinic
        {
            Cnpj = string.Empty,
            Name = string.Empty,
            Address = new Address
            {
                Street = string.Empty,
                Number = string.Empty,
                Complement = string.Empty,
                Neighborhood = string.Empty,
                City = string.Empty,
                State = string.Empty,
                Country = string.Empty,
                ZipCode = string.Empty,
                Reference = string.Empty
            },
            Phone = string.Empty,
            Email = string.Empty,
            Whatsapp = string.Empty,
            WorkingHours = new List<WorkingHours>(),
            Professionals = new List<Professional>()
        });
        dbContext.SaveChanges();
    }
}
catch (Exception e)
{
    Console.WriteLine($"Error {e.Message}");
}

app.UseHttpsRedirection();
app.UseCors(policyBuilder => policyBuilder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseMiddleware(typeof(ErrorMiddleware));
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();