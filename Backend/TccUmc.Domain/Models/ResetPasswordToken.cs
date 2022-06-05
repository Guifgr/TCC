namespace TccUmc.Domain.Models;

public class ResetPasswordToken
{
    public int Id { get; set; }
    public User User { get; set; } = new User();
    public string Token { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
}