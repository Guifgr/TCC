namespace TccUmc.Domain.Models;

public class UserBaseModel
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Address? Address { get; set; }
}