namespace TccBackendUmc.Application.DTO.Request.Users;

public class CreateUserDto
{
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string? Cnpj { get; set; } = string.Empty;
    public AddressDto Address { get; set; } = new AddressDto();
}