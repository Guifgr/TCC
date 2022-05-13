using TccBackendUmc.Domain.Models;

namespace TccBackendUmc.Infrastructure.Interfaces;

public interface IClinicRepository
{
    Task<Clinic> CreateClinic(Clinic clinic);
    Task<Clinic> GetClinicByGuid(Guid guid);
    Task<Clinic> GetClinicById(int id);
    Task<List<Clinic>> GetClinics(Guid guid);
    Task<Clinic> UpdateClinic(Clinic clinic);
    Task<Clinic> GetClinicsByUser(User user);
}