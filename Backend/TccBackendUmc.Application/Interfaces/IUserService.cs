using TccBackendUmc.Application.DTO.Users.Request;
using TccBackendUmc.Application.DTO.Users.Response;

namespace TccBackendUmc.Application.Interfaces;

public interface IUserService
{
    Task<CreateUserResponseDto> CreateUser(CreateUserDto userDto);
}