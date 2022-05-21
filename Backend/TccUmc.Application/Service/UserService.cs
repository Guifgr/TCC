using AutoMapper;
using TccUmc.Application.DTO.Users.Request;
using TccUmc.Application.DTO.Users.Response;
using TccUmc.Domain.Models;
using TccUmc.Infrastructure.IRepository;
using TccUmc.Application.IService;
using TccUmc.Domain.Exceptions;
using TccUmc.Utility.Helpers;

namespace TccUmc.Application.Service;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IMailSender _mailSender;

    public UserService(
        IMapper mapper,
        IUserRepository userRepository,
        IMailSender mailSender)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _mailSender = mailSender;
    }

    public async Task<CreateUserResponseDto> CreateUser(CreateUserDto userDto)
    {
        if (!Validate.IsCpf(userDto.Cpf))
        {
            throw new BadRequestException("Cpf invalido");
        }

        if (userDto.Cnpj != string.Empty && !Validate.IsCnpj(userDto.Cnpj))
        {
            throw new BadRequestException("Cnpj invalido");
        }
        
        var user = _mapper.Map<User>(userDto);
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        user = await _userRepository.CreateUser(user);
        return new CreateUserResponseDto
        {
            UserGuid = user.Guid,
            Email = user.Email
        };
    }

    public async Task ChangePasswordUser(UpdateUserPasswordDto userDto)
    {
        var user = await _userRepository.GetUserByEmail(userDto.Email);
        if (user == null)
        {
            throw new NotFoundException("Email não cadastrado");
        }
        var token = Guid.NewGuid().ToString();
        await _mailSender.SentMailResetPassword(user.Email, token);
    }
}