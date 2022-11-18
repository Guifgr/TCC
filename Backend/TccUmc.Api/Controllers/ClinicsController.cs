using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TccUmc.Application.DTO.Clinic.Request;
using TccUmc.Application.DTO.Clinic.Response;
using TccUmc.Application.IService;
using TccUmc.Domain.Enums;

namespace TccUmc.Api.Controllers;

[Authorize(Role.Clinic)]
[Route("[controller]/[action]")]
public class ClinicController : Controller
{
    private readonly IClinicService _clinicService;

    public ClinicController(IClinicService clinicService)
    {
        _clinicService = clinicService;
    }

    /// <summary>
    ///     Update clinic information
    /// </summary>
    /// <param name="clinicDto">Clinic data</param>
    /// <returns>Clinic resumed data</returns>
    [HttpPut]
    public async Task<UpdateClinicResponseDto> UpdateClinicData([Required] [FromBody] UpdateClinicDto
        clinicDto)
    {
        return await _clinicService.UpdateClinic(clinicDto);
    }

    /// <summary>
    ///     Update working hours
    /// </summary>
    /// <param name="clinicDto">Clinic data</param>
    /// <returns>Clinic resumed data</returns>
    [HttpPatch]
    public async Task<UpdateClinicResponseDto> UpdateClinicWorkingHours([Required] [FromBody]
        UpdateClinicWorkingHoursDto
            clinicDto)
    {
        return await _clinicService.UpdateClinicWorkingHours(clinicDto);
    }
}