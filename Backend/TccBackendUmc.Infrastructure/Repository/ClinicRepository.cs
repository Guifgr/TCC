using Microsoft.EntityFrameworkCore;
using TccBackendUmc.Domain.Exceptions;
using TccBackendUmc.Domain.Models;
using TccBackendUmc.Infrastructure.Database.Context;
using TccBackendUmc.Infrastructure.Interfaces;

namespace TccBackendUmc.Infrastructure.Repository;

public class ClinicRepository : IClinicRepository
{
    private readonly TccContext _context;

    public ClinicRepository(TccContext context)
    {
        _context = context;
    }

    public async Task<Clinic> CreateClinic(Clinic clinic)
    {
        await _context.Clinics.AddAsync(clinic);
        await _context.SaveChangesAsync();
        return clinic;
    }

    public async Task<Clinic> GetClinicByGuid(Guid guid)
    {
        var clinic = await _context.Clinics.Where(x => x.Guid == guid).FirstOrDefaultAsync();
        if (clinic == default)
        {
            throw new NotFoundException("Clinica não encontrada");
        }

        return clinic;
    }

    public async Task<Clinic> GetClinicById(int id)
    {
        var clinic = await _context.Clinics.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (clinic == default)
        {
            throw new NotFoundException("Clinica não encontrada");
        }

        return clinic;
    }

    public async Task<Clinic?> GetClinicByOwner(Guid guid)
    {
        var user = _context.Users.FirstOrDefault(x => x.Guid == guid);
        if (user == default)
        {
            throw new NotFoundException("Usuário não tem Clinica");
        }

        return await _context.Clinics.Where(x => x.Owners.Contains(user)).FirstOrDefaultAsync();
    }

    public async Task<List<Clinic>> GetClinics(Guid guid)
    {
        return await _context.Clinics.ToListAsync();
    }

    public async Task<Clinic> UpdateClinic(Clinic clinic)
    {
        var clinicEntity = await GetClinicByGuid(clinic.Guid);
        if (clinicEntity == null)
        {
            throw new Exception("Clinica não encontrada");
        }

        clinicEntity.Name = clinic.Name;
        clinicEntity.Phone = clinic.Phone;
        clinicEntity.Email = clinic.Email;
        clinicEntity.Whatsapp = clinic.Whatsapp;
        clinicEntity.Whatsapp = clinic.Whatsapp;
        clinicEntity.WorkingHours = clinic.WorkingHours;
        await _context.SaveChangesAsync();
        return clinic;
    }

    public async Task<Clinic> GetClinicsByUser(User user)
    {
        var clinic  = await _context.Clinics.Where(x => x.Owners.Contains(user)).FirstOrDefaultAsync();
        if (clinic == default)
        {
            throw new NotFoundException("Clinica não encontrada");
        }
        return clinic;
    }
}