using Microsoft.EntityFrameworkCore;
using TccUmc.Domain.Exceptions;
using TccUmc.Domain.Models;
using TccUmc.Infrastructure.Database.Context;
using TccUmc.Infrastructure.IRepository;

namespace TccUmc.Infrastructure.Repository;

public class DashboardRepository : IDashboardRepository
{
    private readonly TccContext _context;

    public DashboardRepository(TccContext context)
    {
        _context = context;
    }


    public async Task<Dashboard> GetDashboard(int userId)
    {
        var dashboard = new Dashboard();
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == default)
        {
            throw new BadRequestException("Usuário não encontrado");
        }
        
        var clinic = await _context.Clinics
            .Include(c => c.Procedures)
            .Include(c => c.Consults)
            .ThenInclude(c => c.User)
            .Include(c =>c.Consults)
            .ThenInclude(c => c.PendingExams)
            .FirstAsync();


        var personalInfo = new List<PendingPersonalInfo>();
        if (string.IsNullOrEmpty(user.Name))
        {
            personalInfo.Add(PendingPersonalInfo.Nome);
        }

        if (string.IsNullOrEmpty(user.Email))
        {
            personalInfo.Add(PendingPersonalInfo.Email);
        }

        if (string.IsNullOrEmpty(user.Cpf) && string.IsNullOrEmpty(user.Cnpj))
        {
            personalInfo.Add(PendingPersonalInfo.Documento);
        }

        dashboard.PendingPersonalInfo = personalInfo;

        dashboard.PendingConsults = new List<PendingConsults>();
        dashboard.PendingExams = new List<PendingExams>();
        dashboard.DebtsList = new DebtsList
        {
            Debts = new List<Debts>()
        };
        
        if (clinic == null)
        {
            throw new BadRequestException("Clinica não encontrada");
        }

        if(clinic.Consults != null && clinic.Consults.Any())
        {
            var consults = clinic.Consults.Where(c => c.User.Id == userId).ToList();
            foreach (var consult in consults)
            {
                dashboard.PendingConsults.Add(new PendingConsults
                {
                    ProcedureName = consult.Procedure.Name,
                    Date = consult.ConsultStart
                });

                dashboard.DebtsList.Debts.Add(new Debts
                {
                    ProcedureName = consult.Procedure.Name,
                    ProcedurePrice = consult.Procedure.Price,
                });

                foreach (var exam in consult.PendingExams)
                {
                    dashboard.PendingExams.Add(new PendingExams
                    {
                        ProcedureName = exam.Name,
                    });
                    
                    dashboard.DebtsList.Debts.Add(new Debts
                    {
                        ProcedureName = exam.Name,
                        ProcedurePrice = exam.Price,
                    });
                }
            }
        }


        var total = dashboard.DebtsList.Debts.Sum(debt => debt.ProcedurePrice);
        dashboard.DebtsList.Total = total;

        return dashboard;
    }
}