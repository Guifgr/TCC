using TccBackendUmc.Domain.Enums;

namespace TccBackendUmc.Application.DTO.Response;

public class LoginResponseDto
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public PermissionLevelEnum PermissionLevel { get; set; }
}