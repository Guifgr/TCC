namespace TccUmc.Domain.Models;

public class Dashboard
{
    public DebtsList DebtsList { get; set; } = new DebtsList();
    public List<PendingPersonalInfo> PendingPersonalInfo { get; set; } = new List<PendingPersonalInfo>();
    public List<PendingConsults> PendingConsults { get; set; } = new List<PendingConsults>();
    public List<PendingExams> PendingExams { get; set; } = new List<PendingExams>();
}

public class PendingConsults
{
    public string ProcedureName { get; set; }
    public DateTime Date { get; set; }
}

public class PendingExams
{
    public string ProcedureName { get; set; }
}

public enum PendingPersonalInfo
{
    Nome,
    Email,
    Documento
}

public class DebtsList
{
    public List<Debts> Debts { get; set; }
    public double Total { get; set; }
}

public class Debts
{
    public string ProcedureName { get; set; }
    public double ProcedurePrice { get; set; }
}
