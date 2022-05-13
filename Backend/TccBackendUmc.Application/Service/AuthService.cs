using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using TccBackendUmc.Application.DTO.Login.Request;
using TccBackendUmc.Application.DTO.Login.Response;
using TccBackendUmc.Application.Interfaces;
using TccBackendUmc.Domain.Enums;
using TccBackendUmc.Infrastructure.Interfaces;

namespace TccBackendUmc.Application.Service;

public class AuthService : IAuthService
{
    private readonly ITokenService _serviceToken;
    private readonly IUserRepository _userRepository;
    private readonly IClinicRepository _clinicRepository;

    public AuthService(
        ITokenService serviceToken,
        IUserRepository userRepository, IClinicRepository clinicRepository)
    {
        _serviceToken = serviceToken;
        _userRepository = userRepository;
        _clinicRepository = clinicRepository;
    }

    public async Task<LoginResponseDto> UserLogin(UserLoginRequestDto model)
    {
        var user = await _userRepository.GetUserByCredentials(model.Email, model.Password);
        _userRepository.VerifyUserPassword(model.Password, user);
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Email),
            new("id", user.Id.ToString()),
            new(ClaimTypes.Role, Role.User.ToString())
        };

        var (token, hours) = _serviceToken.GenerateToken(claims);
        return new LoginResponseDto
        {
            ExpirationDate = DateTime.Now.AddHours(hours),
            Token = token,
            Role = Role.User
        };
    }

    public async Task<LoginResponseDto> ClinicLogin(ClincLoginRequestDto model)
    {
        var user = await _userRepository.GetUserByCredentials(model.Email, model.Password);
        _userRepository.VerifyUserPassword(model.Password, user);
        var clinic = await _clinicRepository.GetClinicsByUser(user);
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Email),
            new("id", clinic.Id.ToString()),
            new(ClaimTypes.Role, Role.Clinic.ToString())
        };
        var (token, hours) = _serviceToken.GenerateToken(claims);
        return new LoginResponseDto
        {
            ExpirationDate = DateTime.Now.AddHours(hours),
            Token = token,
            Role = Role.Clinic
        };
    }
}