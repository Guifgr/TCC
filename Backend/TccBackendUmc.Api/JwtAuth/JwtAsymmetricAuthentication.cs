using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using TccBackendUmc.Utility.Extensions;
using TccBackendUmc.Utility.Security;

namespace TccBackendUmc.Api.JwtAuth;

public static class JwtAuthExtensions
{
    public static void AddJwtAsymmetricAuthentication(this IServiceCollection services)
    {
        var issuer = EnvironmentVariableExtension.GetEnvironmentVariable<string>("", "TOKEN:ISSUER");

        SecurityKey rsaSigningKey = RSA.Create().GetPublicSigningKey(); 

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = rsaSigningKey,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

        services.AddAuthorization(options =>
        {
            options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
        });

    }
}