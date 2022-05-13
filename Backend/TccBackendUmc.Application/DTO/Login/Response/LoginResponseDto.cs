using TccBackendUmc.Domain.Enums;

namespace TccBackendUmc.Application.DTO.Login.Response;

public class LoginResponseDto
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public Role Role { get; set; }
}