namespace TccUmc.Domain.Models;

public class FirstAccessToken
{
    public int Id { get; set; }
    public User User { get; set; } = new User();
    public string Token { get; set; } = string.Empty;
    public bool WasUsed { get; set; }
}