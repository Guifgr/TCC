namespace TccUmc.Application.DTO;

public class WorkingHoursDto
{
    public DateTime Open { get; set; }
    public DateTime Close { get; set; }
    public DayOfWeek DayOfWeek { get; set; } 
    public bool Active { get; set; }
}