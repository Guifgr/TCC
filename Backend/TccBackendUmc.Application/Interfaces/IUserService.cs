using TccBackendUmc.Application.DTO.Request.Users;
using TccBackendUmc.Application.DTO.Response.User;

namespace TccBackendUmc.Application.Interfaces;

public interface IUserService
{
    Task<CreateUserResponseDto> CreateUser(CreateUserDto userDto);
}