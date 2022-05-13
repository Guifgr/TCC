using TccBackendUmc.Application.DTO.Login.Request;
using TccBackendUmc.Application.DTO.Login.Response;

namespace TccBackendUmc.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto> UserLogin(UserLoginRequestDto model);
    Task<LoginResponseDto> ClinicLogin(ClincLoginRequestDto model);
}