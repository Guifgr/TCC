namespace TccUmc.Application.DTO.Users.Response;

public class CreateUserResponseDto
{
    public Guid UserGuid { get; set; }
    public string Email { get; set; } = string.Empty;
}