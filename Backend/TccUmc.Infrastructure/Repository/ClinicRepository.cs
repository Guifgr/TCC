using Microsoft.EntityFrameworkCore;
using TccUmc.Domain.Enums;
using TccUmc.Domain.Exceptions;
using TccUmc.Domain.Models;
using TccUmc.Infrastructure.Database.Context;
using TccUmc.Infrastructure.IRepository;

namespace TccUmc.Infrastructure.Repository;

public class ClinicRepository : IClinicRepository
{
    private readonly TccContext _context;

    public ClinicRepository(TccContext context)
    {
        _context = context;
    }


    public async Task<Clinic> GetClinic()
    {
        var clinic = await _context.Clinics
            .Include(u => u.Address)
            .Include(u => u.Professionals)
            .Include(u => u.WorkingHours)
            .Include(u => u.Procedures)
            .Include(u => u.Consults)
            .FirstAsync();
        return clinic;
    }

    public async Task<Clinic> GetClinicById()
    {
        return await _context.Clinics
            .FirstAsync();
    }

    public async Task<Clinic> UpdateClinic(Clinic clinic)
    {
        var clinicEntity = await GetClinic();
        if (clinicEntity == null) throw new Exception("Clinica não encontrada");
        clinic.Id = clinicEntity.Id;
        await _context.SaveChangesAsync();
        return clinic;
    }

    public async Task<Clinic> UpdateClinicHours(Clinic clinic)
    {
        var clinicEntity = await GetClinic();
        if (clinicEntity == null) throw new Exception("Clinica não encontrada");

        clinicEntity.WorkingHours = clinic.WorkingHours;
        await _context.SaveChangesAsync();
        return clinic;
    }

    public async Task<Procedure> CreateClinicProcedureAsync(Procedure procedure)
    {
        var clinic = await GetClinic();
        clinic.Procedures?.Add(procedure);
        await _context.SaveChangesAsync();
        return procedure;
    }

    public async Task<List<Procedure>> GetClinicProcedures()
    {
        return await _context.Clinics
            .Include(c => c.Procedures)
            .SelectMany(c => c.Procedures)
            .ToListAsync();
    }

    public async Task<Procedure> GetClinicProcedureByGuid(Guid procedure)
    {
        var clinic = await _context.Clinics.Include(c => c.Procedures).FirstAsync();

        var procedureEntity = clinic.Procedures?.FirstOrDefault(p => p.Guid == procedure);

        if (procedureEntity == null)
        {
            throw new BadRequestException("Procedimento não encontrado");
        }

        return procedureEntity;
    }

    public async Task<List<Professional>> GetClinicProfessionals()
    {
        return await _context.Clinics
            .Include(c => c.Professionals)
            .SelectMany(c => c.Professionals)
            .ToListAsync();
    }

    public async Task<Professional> GetClinicProfessionalByGuid(Guid? professional)
    {
        var clinic = await _context.Clinics
            .Include(c => c.Professionals)
            .FirstAsync();

        var professionalEntity = clinic.Professionals.FirstOrDefault(p => p.Guid == professional);
        if (professionalEntity == default) throw new BadRequestException("Profissional não encontrado");

        return professionalEntity;
    }

    public async Task<Professional> CreateNewClinicProfessional(Professional professional)
    {
        var clinic = _context.Clinics
            .Include(c => c.Professionals)
            .First();
        clinic.Professionals.Add(professional);
        await _context.SaveChangesAsync();
        return clinic.Professionals.First(p => p.ProfessionalDoc == professional.ProfessionalDoc);
    }

    public async Task<List<Consult>> GetConsultsByDate(DateTime date)
    {
        var consults = await _context.Clinics
            .SelectMany(c => c.Consults)
            .Where(c => c.ConsultStart.Date == date.Date)
            .ToListAsync();
        return consults;
    }

    public async Task<Consult> CreateConsult(Consult consultEntity)
    {
        var clinic = await _context.Clinics
            .Include(c => c.Consults)
            .FirstAsync();
        consultEntity.Clinic = clinic;
        clinic.Consults ??= new List<Consult>();
        clinic.Consults.Add(consultEntity);
        await _context.SaveChangesAsync();
        return consultEntity;
    }

    public async Task<Procedure> UpdateClinicProcedure(Procedure procedureEntity)
    {
        var clinicProcedures = await _context.Clinics.Include(c => c.Procedures)
            .ThenInclude(p => p.QualifieldProfessionals).FirstAsync();
        if (clinicProcedures.Procedures == null)
        {
            throw new BadRequestException("Procedimento não encontrado");
        }

        var procedure =
            clinicProcedures.Procedures.FirstOrDefault(p => p.Guid == procedureEntity.Guid);

        if (procedure == null)
        {
            throw new BadRequestException("Procedimento não encontrado");
        }

        procedure.Duration = procedureEntity.Duration;
        procedure.Name = procedureEntity.Name;
        procedure.Price = procedureEntity.Price;
        procedure.QualifieldProfessionals = procedureEntity.QualifieldProfessionals;
        await _context.SaveChangesAsync();
        return procedure;
    }

    public async Task<List<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public void DeleteConsult(Consult consult)
    {
        _context.Entry(consult).State = EntityState.Deleted;
        _context.SaveChanges();
    }

    public async Task<List<Consult>> GetConsults(int userId, Role role)
    {
        var consults = await _context.Clinics
            .SelectMany(c => c.Consults)
            .Include(c => c.Clinic)
            .ThenInclude(c => c.Address)
            .Include(c => c.User)
            .Include(c => c.Procedure)
            .Include(c => c.Professional)
            .ToListAsync();

        if (role == Role.User)
        {
            consults = consults.Where(c => c.User.Id == userId).ToList();
        }

        return consults;
    }

    public async Task<Clinic> CreateClinic(Clinic clinic)
    {
        await _context.Clinics.AddAsync(clinic);
        await _context.SaveChangesAsync();
        return clinic;
    }
}