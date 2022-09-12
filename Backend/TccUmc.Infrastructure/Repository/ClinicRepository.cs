using Microsoft.EntityFrameworkCore;
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
        return await _context.Clinics
            .Include(u => u.Address)
            .Include(u => u.Professionals)
            .Include(u => u.WorkingHours)
            .FirstAsync();
    }

    public async Task<Clinic> UpdateClinic(Clinic clinic)
    {
        var clinicEntity = await GetClinic();
        if (clinicEntity == null) throw new Exception("Clinica não encontrada");
        clinic.Id = clinicEntity.Id;
        clinicEntity = clinic;
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

    public async Task<Clinic> CreateClinic(Clinic clinic)
    {
        await _context.Clinics.AddAsync(clinic);
        await _context.SaveChangesAsync();
        return clinic;
    }
}