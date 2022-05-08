using Microsoft.EntityFrameworkCore;
using TccBackendUmc.Application.Middleware;
using TccBackendUmc.Infrastructure.Database.Context;
using TccBackendUmc.Ioc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DependencyInjectionContainer.RegisterServices(builder.Services);

using var dbContext = new MssqlContext();
dbContext.Database.Migrate();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware(typeof(ErrorMiddleware));
app.Run();