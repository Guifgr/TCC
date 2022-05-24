using System.Security.Claims;

namespace TccUmc.Application.IService;

public interface ITokenService
{
    (string token, int hours) GenerateToken(IEnumerable<Claim> claims);
}