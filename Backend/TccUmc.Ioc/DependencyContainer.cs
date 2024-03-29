﻿using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using TccUmc.Application.IService;
using TccUmc.Application.Service;
using TccUmc.Infrastructure.Database.Context;
using TccUmc.Infrastructure.IRepository;
using TccUmc.Infrastructure.Repository;

namespace TccUmc.Ioc;

[ExcludeFromCodeCoverage]
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
        services.AddScoped<IDashboardService, DashboardService>();

        //Repository
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IClinicRepository, ClinicRepository>();
        services.AddScoped<IResetPassword, ResetPassword>();
        services.AddScoped<IMailSender, MailSender>();
        services.AddScoped<IValidateAccountToken, ValidateAccountToken>();
        services.AddScoped<IDashboardRepository, DashboardRepository>();


        //Data
        services.AddScoped<TccContext>();
    }
}