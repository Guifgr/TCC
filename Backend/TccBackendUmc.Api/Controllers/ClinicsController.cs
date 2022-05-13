using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccBackendUmc.Application.DTO.Clinic.Request;
using TccBackendUmc.Application.DTO.Clinic.Response;
using TccBackendUmc.Application.Interfaces;

namespace TccBackendUmc.Api.Controllers;

[Authorize(Roles = "Clinic")]
[Route("[controller]/[action]")]
public class ClinicController : Controller
{
    private readonly IClinicService _clinicService;

    public ClinicController(IClinicService clinicService)
    {
        _clinicService = clinicService;
    }

    /// <summary>
    /// Create a new Clinic
    /// </summary>
    /// <param name="clinicDto">Clinic data</param>
    /// <returns>Clinic resumed data</returns>
    [HttpPost]
    public async Task<CreateClinicResponseDto> CreateClinic([FromBody] CreateClinicDto
        clinicDto)
    {
        return await _clinicService.CreateClinic(clinicDto, int.Parse(User.FindFirst("id")?.Value ?? string.Empty));
    }
    
    /// <summary>
    /// Create a new Clinic
    /// </summary>
    /// <param name="clinicDto">Clinic data</param>
    /// <returns>Clinic resumed data</returns>
    [HttpPut]
    public async Task<CreateClinicResponseDto> UpdateClinicData([FromBody] UpdateClinicDto
        clinicDto)
    {
        return await _clinicService.UpdateClinic(clinicDto, int.Parse(User.FindFirst("id")?.Value ?? string.Empty));
    }
    
    /// <summary>
    /// Create a new Clinic
    /// </summary>
    /// <param name="clinicDto">Clinic data</param>
    /// <returns>Clinic resumed data</returns>
    [HttpPatch]
    public async Task<CreateClinicResponseDto> UpdateClinicWorkingHours([FromBody] UpdateClinicWorkingHoursDto
        clinicDto)
    {
        return await _clinicService.UpdateClinicWorkingHours(clinicDto, int.Parse(User.FindFirst("id")?.Value ?? string.Empty));
    }
    
}