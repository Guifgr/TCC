using Microsoft.Extensions.DependencyInjection;
using TccBackendUmc.Application.Interfaces;
using TccBackendUmc.Application.Service;
using TccBackendUmc.Infrastructure.Database.Context;
using TccBackendUmc.Infrastructure.IRepository;
using TccBackendUmc.Infrastructure.Repository;

namespace TccBackendUmc.Ioc;

public static class DependencyInjectionContainer
{
    public static void RegisterServices(IServiceCollection services)
    {
        //AutoMapper
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        //Services
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        
        //Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMailSender, MailSender>();
        
        //Database
        services.AddScoped<MssqlContext>();
    }
}