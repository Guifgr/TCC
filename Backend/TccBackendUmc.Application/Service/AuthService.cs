using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using TccBackendUmc.Application.DTO.Request;
using TccBackendUmc.Application.DTO.Response;
using TccBackendUmc.Application.Interfaces;
using TccBackendUmc.Infrastructure.IRepository;

namespace TccBackendUmc.Application.Service;

public class AuthService : IAuthService
{
    private readonly ITokenService _serviceToken;
    private readonly IUserRepository _userRepository;

    public AuthService(
        ITokenService serviceToken,
        IUserRepository userRepository
    )
    {
        _serviceToken = serviceToken;
        _userRepository = userRepository;
    }

    public LoginResponseDto Login(LoginRequestDto model)
    {
        var user = _userRepository.GetUserByCredentials(model.Email, model.Password);
        _userRepository.VerifyUserPassword(model.Password, user);
        _userRepository.SaveLastAccess(user, DateTime.Now);
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Email),
            new("id", user.Id.ToString()),
            new(ClaimTypes.Role, user.PermissionLevelEnum.ToString())
        };
        var (token, hours) = _serviceToken.GenerateToken(claims);
        return new LoginResponseDto
        {
            ExpirationDate = DateTime.Now.AddHours(hours),
            Token = token,
            PermissionLevel = user.PermissionLevelEnum,
        };
    }
}