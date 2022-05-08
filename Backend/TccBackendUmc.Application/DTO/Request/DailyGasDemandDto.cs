using System.ComponentModel.DataAnnotations;

namespace TccBackendUmc.Application.DTO.Request
{
    public class DailyGasDemandDto
    {
        [Required] public DateTime Date { get; set; }
        [Required] public double Quantity { get; set; }
    }
}
