using System.Security.Claims;
using TccUmc.Infrastructure.IRepository;
using Microsoft.IdentityModel.JsonWebTokens;
using TccUmc.Application.DTO.Request;
using TccUmc.Application.DTO.Response;
using TccUmc.Application.IService;
using TccUmc.Domain.Enums;
using TccUmc.Domain.Exceptions;

namespace TccUmc.Application.Service;

public class AuthService : IAuthService
{
    private readonly ITokenService _serviceToken;
    private readonly IUserRepository _userRepository;
    private readonly IValidateAccountToken _validateAccountToken;
    private readonly IClinicRepository _clinicRepository;
    private readonly IMailSender _mail;

    public AuthService(
        ITokenService serviceToken,
        IUserRepository userRepository,
        IClinicRepository clinicRepository,
        IMailSender mail, IValidateAccountToken validateAccountToken)
    {
        _serviceToken = serviceToken;
        _userRepository = userRepository;
        _clinicRepository = clinicRepository;
        _mail = mail;
        _validateAccountToken = validateAccountToken;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto model)
    {
        var user = await _userRepository.GetUserByCredentials(model.Email);
        if (!user.IsActive)
        {
            var newToken = await _validateAccountToken.RecreateValidateToken(user);
            await _mail.SentMailResetValidateAccount(user.Email, newToken.Token);
            throw new ForbiddenException("Usuário ainda não confirmou a conta por email!");
        }
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
            WasPostRegistered = user.Name.Length > 0
        };
    }
}