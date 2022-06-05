using System.Security.Claims;
using TccUmc.Infrastructure.IRepository;
using Microsoft.IdentityModel.JsonWebTokens;
using TccUmc.Application.DTO.Request;
using TccUmc.Application.DTO.Response;
using TccUmc.Application.IService;
using TccUmc.Domain.Enums;

namespace TccUmc.Application.Service;

public class AuthService : IAuthService
{
    private readonly ITokenService _serviceToken;
    private readonly IUserRepository _userRepository;
    private readonly IClinicRepository _clinicRepository;
    private readonly IMailSender _mail;

    public AuthService(
        ITokenService serviceToken,
        IUserRepository userRepository,
        IClinicRepository clinicRepository,
        IMailSender mail
    )
    {
        _serviceToken = serviceToken;
        _userRepository = userRepository;
        _clinicRepository = clinicRepository;
        _mail = mail;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto model)
    {
        var user = await _userRepository.GetUserByCredentials(model.Email);
        _userRepository.VerifyUserPassword(model.Password, user);
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Email),
            new("id", user.Id.ToString()),
            new(ClaimTypes.Role, user.Role.ToString()),
            new(ClaimTypes.Email, user.Email),
        };
        var (token, hours) = _serviceToken.GenerateToken(claims);
        return new LoginResponseDto
        {
            ExpirationDate = DateTime.Now.AddHours(hours),
            Token = token,
            PermissionLevel = user.Role,
            UserName = user.Name,
        };
    }
}