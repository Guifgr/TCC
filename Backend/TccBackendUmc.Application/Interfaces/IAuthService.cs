using TccBackendUmc.Application.DTO.Request;
using TccBackendUmc.Application.DTO.Response;

namespace TccBackendUmc.Application.Interfaces;

public interface IAuthService
{
    LoginResponseDto Login(LoginRequestDto model);
}