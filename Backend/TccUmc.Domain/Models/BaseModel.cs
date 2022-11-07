namespace TccUmc.Domain.Models;

public abstract class BaseModel
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
}