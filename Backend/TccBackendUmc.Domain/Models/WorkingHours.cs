namespace TccBackendUmc.Domain.Models;

public class WorkingHours
{
    public int Id { get; set; }
    public DateTime Open { get; set; }
    public DateTime Close { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public bool Active { get; set; }
}