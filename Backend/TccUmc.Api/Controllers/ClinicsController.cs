using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccUmc.Application.DTO.Clinic.Request;
using TccUmc.Application.DTO.Clinic.Response;
using TccUmc.Application.IService;

namespace TccUmc.Api.Controllers;

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
    [HttpPut]
    public async Task<CreateClinicResponseDto> UpdateClinicData([Required][FromBody] UpdateClinicDto
        clinicDto)
    {
        return await _clinicService.UpdateClinic(clinicDto);
    }
    
    /// <summary>
    /// Update working hours
    /// </summary>
    /// <param name="clinicDto">Clinic data</param>
    /// <returns>Clinic resumed data</returns>
    [HttpPatch]
    public async Task<CreateClinicResponseDto> UpdateClinicWorkingHours([Required][FromBody] UpdateClinicWorkingHoursDto
        clinicDto)
    {
        return await _clinicService.UpdateClinicWorkingHours(clinicDto);
    }
}