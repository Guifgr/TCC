namespace TccUmc.Application.DTO;

public class DashboardGetDto
{
    public List<DebtsList> Debts { get; set; }
    public List<PendingPersonalInfo> PendingPersonalInfo { get; set; }
    public List<PendingConsults> PendingConsults { get; set; }
    public List<PendingExams> PendingExams { get; set; }
}

public class PendingConsults
{
    public string ProcedureName { get; set; }
    public DateTime Date { get; set; }
}

public class PendingExams
{
    public string ProcedureName { get; set; }
    public DateTime Date { get; set; }
}

public class PendingPersonalInfo
{
    public string PersonalInfoPending { get; set; }
}

public class DebtsList
{
    public List<Debts> Debts { get; set; }
    public double Total { get; set; }
}

public abstract class Debts
{
    public string ProcedureName { get; set; }
    public double ProcedurePrice { get; set; }
}