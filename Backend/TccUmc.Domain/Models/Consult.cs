using Microsoft.AspNetCore.Identity;
using TccUmc.Domain.Enums;

namespace TccUmc.Domain.Models;

public class Consult : BaseModel
{
    public Professional Professional { get; set; }
    public Clinic Clinic { get; set; }
    public User User { get; set; }
    public DateTime ConsultStart { get; set; }
    public DateTime ConsultEnd { get; set; }
    public string Observations { get; set; } = string.Empty;
    public ConsultStatus Status { get; set; }
    public Procedure Procedure { get; set; }
    public List<Procedure> PendingExams { get; set; }
    
    public PaymentStatus PaymentStatus { get; set; }
}