using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TccBackendUmc.Application.Middleware;
using TccBackendUmc.Infrastructure.Database.Context;
using TccBackendUmc.Ioc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddControllers()
    .AddJsonOptions(opts =>
    {
        var enumConverter = new JsonStringEnumConverter();
        opts.JsonSerializerOptions.Converters.Add(enumConverter);
    });

DependencyInjectionContainer.RegisterServices(builder.Services);

using var dbContext = new TccContext();
dbContext.Database.Migrate();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    
}
app.UseSwagger();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials

app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware(typeof(ErrorMiddleware));
app.Run();