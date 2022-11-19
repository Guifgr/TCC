using TccUmc.Domain.Models;

namespace TccUmc.Application.DTO;

public class DashboardGetDto
{
    public DebtsList DebtsList { get; set; } = new DebtsList();
    public List<PendingPersonalInfo> PendingPersonalInfo { get; set; } = new List<PendingPersonalInfo>();
    public List<PendingConsults> PendingConsults { get; set; } = new List<PendingConsults>();
    public List<PendingExams> PendingExams { get; set; } = new List<PendingExams>();
}