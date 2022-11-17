using TccUmc.Domain.Enums;
using TccUmc.Domain.Models;

namespace TccUmc.Infrastructure.IRepository;

public interface IClinicRepository
{
    Task<Clinic> GetClinic();
    Task<Clinic> GetClinicById();
    Task<Clinic> UpdateClinic(Clinic clinic);
    Task<Clinic> UpdateClinicHours(Clinic clinic);
    Task<Procedure> CreateClinicProcedureAsync(Procedure procedure);
    Task<List<Procedure>> GetClinicProcedures();
    Task<Procedure> GetClinicProcedureByGuid(Guid procedure);
    Task<List<Professional>> GetClinicProfessionals();
    Task<Professional> GetClinicProfessionalByGuid(Guid? professional);
    Task<Professional> CreateNewClinicProfessional(Professional professional);
    Task<List<Consult>> GetConsults(int userId, Role role);
    Task<List<Consult>> GetConsultsByDate(DateTime date);
    Task<Consult> CreateConsult(Consult consultEntity);
}