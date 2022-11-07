using TccUmc.Domain.Enums;

namespace TccUmc.Domain.Models;

public class Consult : BaseModel
{
    public Professional Professional { get; set; }
    public Clinic Clinic { get; set; }
    public User User { get; set; }
    public DateTime Date { get; set; }
    public string Observations { get; set; }
    public ConsultType Type { get; set; }
    public ConsultStatus Status { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
}