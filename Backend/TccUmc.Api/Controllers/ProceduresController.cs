using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TccUmc.Application.DTO.Clinic.Request;
using TccUmc.Application.DTO.Procedures;
using TccUmc.Application.IService;
using TccUmc.Domain.Enums;
using TccUmc.Domain.Exceptions;

namespace TccUmc.Api.Controllers;

[Route("[controller]/[action]")]
public class ProceduresController : Controller
{
    private readonly IClinicService _clinicService;
    public ProceduresController(IClinicService clinicService)
    {
        _clinicService = clinicService;
    }

    /// <summary>
    ///     Update clinic information
    /// </summary>
    /// <returns>Clinic resumed data</returns>
    [Authorize(Role.Clinic, Role.Admin, Role.Professional)]
    [HttpPost]
    public async Task<ClinicProcedureDTO> CreateClinicProcedure([FromBody] [Required] ClinicProcedureCreateDTO procedure)
    {
        if (!ModelState.IsValid)
        {
            throw new BadRequestException(ModelState.ToString() ?? string.Empty);
        }

        return await _clinicService.CreateClinicProcedure(procedure);
    }
}