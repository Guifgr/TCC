using Microsoft.EntityFrameworkCore;
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

    public async Task<Clinic> CreateClinic(Clinic clinic)
    {
        await _context.Clinics.AddAsync(clinic);
        await _context.SaveChangesAsync();
        return clinic;
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
        if (clinicEntity == null)
        {
            throw new Exception("Clinica não encontrada");
        }

        clinicEntity.Cnpj = clinic.Cnpj;
        clinicEntity.Name = clinic.Name;
        clinicEntity.Phone = clinic.Phone;
        clinicEntity.Email = clinic.Email;
        clinicEntity.Whatsapp = clinic.Whatsapp;
        clinicEntity.WorkingHours = clinic.WorkingHours;
        
        clinicEntity.Address.Number = clinic.Address.Number;
        clinicEntity.Address.Street = clinic.Address.Street;
        clinicEntity.Address.Complement = clinic.Address.Complement;
        clinicEntity.Address.Reference = clinic.Address.Reference;
        clinicEntity.Address.Neighborhood = clinic.Address.Neighborhood;
        clinicEntity.Address.City = clinic.Address.City;
        clinicEntity.Address.State = clinic.Address.State;
        clinicEntity.Address.Country = clinic.Address.Country;
        clinicEntity.Address.ZipCode = clinic.Address.ZipCode;

        await _context.SaveChangesAsync();
        return clinic;
    }
}