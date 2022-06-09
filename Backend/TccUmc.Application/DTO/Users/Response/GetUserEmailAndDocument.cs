namespace TccUmc.Application.DTO.Users.Response;

public class GetUserEmailAndDocument
{
    public Guid Guid { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
}