namespace TccBackendUmc.Application.DTO.Response.User;

public class CreateUserResponseDto
{
    public Guid UserGuid { get; set; }
    public string Email { get; set; } = string.Empty;
}