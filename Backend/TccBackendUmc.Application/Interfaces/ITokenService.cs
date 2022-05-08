using System.Security.Claims;

namespace TccBackendUmc.Application.Interfaces;

public interface ITokenService
{
    (string token, int hours) GenerateToken(List<Claim> claims);
}