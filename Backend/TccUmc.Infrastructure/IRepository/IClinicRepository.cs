using TccUmc.Domain.Models;

namespace TccUmc.Infrastructure.IRepository;

public interface IClinicRepository
{
    Task<Clinic> GetClinic();
    Task<Clinic> UpdateClinic(Clinic clinic);
    Task<Clinic> UpdateClinicHours(Clinic clinic);
}