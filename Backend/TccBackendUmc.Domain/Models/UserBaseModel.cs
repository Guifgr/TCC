using TccBackendUmc.Domain.Enums;

namespace TccBackendUmc.Domain.Models;

public class UserBaseModel
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Address Address { get; set; }
}