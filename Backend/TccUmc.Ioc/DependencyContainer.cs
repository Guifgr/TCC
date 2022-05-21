using TccUmc.Application.IService;
using TccUmc.Application.Service;
using Microsoft.Extensions.DependencyInjection;
using TccUmc.Infrastructure.Database.Context;
using TccUmc.Infrastructure.IRepository;
using TccUmc.Infrastructure.Repository;
using TccUmc.Utility.Security;

namespace TccUmc.Ioc
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            //Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClinicService, ClinicService>();

            //Repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClinicRepository, ClinicRepository>();
            services.AddScoped<IMailSender, MailSender>();

            //Data
            services.AddScoped<TccContext>();
        }
    }
}