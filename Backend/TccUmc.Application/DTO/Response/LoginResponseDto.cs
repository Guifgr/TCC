using TccUmc.Domain.Enums;

namespace TccUmc.Application.DTO.Response;

public class LoginResponseDto
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public Role PermissionLevel { get; set; }
    public string UserName { get; set; } = string.Empty;
    public bool WasPostRegistered { get; set; }
}