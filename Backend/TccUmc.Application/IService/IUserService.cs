using TccUmc.Application.DTO.Users.Request;
using TccUmc.Application.DTO.Users.Response;

namespace TccUmc.Application.IService;

public interface IUserService
{
    Task<CreateUserResponseDto> CreateUser(CreateUserDto userDto);
    Task ChangePasswordUser(UpdateUserPasswordDto userDto);
}