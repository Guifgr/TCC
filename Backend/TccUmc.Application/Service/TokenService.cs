using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using TccUmc.Application.IService;
using TccUmc.Utility.Extensions;
using TccUmc.Utility.Security;

namespace TccUmc.Application.Service;

public class TokenService : ITokenService
{
    private readonly int _tokenExpiresHours;
    private readonly string _tokenIssuer;

    public TokenService()
    {
        _tokenExpiresHours =
            EnvironmentVariableExtension.GetEnvironmentVariable<int>("", "TOKEN:EXPIRES-HOURS");
        _tokenIssuer = EnvironmentVariableExtension.GetEnvironmentVariable<string>("", "TOKEN:ISSUER");
    }

    public (string token, int hours) GenerateToken(IEnumerable<Claim> claims)
    {
        var signingCredentials = new SigningCredentials(
            RSA.Create().GetPrivateSigningKey(),
            SecurityAlgorithms.RsaSha256);

        var token = new JwtSecurityToken(
            _tokenIssuer,
            expires: DateTime.Now.AddHours(_tokenExpiresHours),
            signingCredentials: signingCredentials,
            claims: claims
        );

        return (new JwtSecurityTokenHandler().WriteToken(token), _tokenExpiresHours);
    }
}