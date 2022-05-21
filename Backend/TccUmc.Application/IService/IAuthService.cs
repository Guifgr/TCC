using TccUmc.Application.DTO.Request;
using TccUmc.Application.DTO.Response;

namespace TccUmc.Application.IService;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto model);
}