using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TccUmc.Application.DTO.Clinic.Request;
using TccUmc.Application.DTO.Procedures;
using TccUmc.Application.IService;
using TccUmc.Domain.Enums;
using TccUmc.Domain.Exceptions;

namespace TccUmc.Api.Controllers;

[Authorize]
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
    [HttpPost]
    public async Task<ProcedureGetDto> CreateClinicProcedure(
        [FromBody] [Required] ProcedurePostDto procedure
        )
    {
        if (!ModelState.IsValid)
        {
            throw new BadRequestException(ModelState.ToString() ?? string.Empty);
        }

        return await _clinicService.CreateClinicProcedure(procedure);
    }

    /// <summary>
    ///     Get clinic procedures
    /// </summary>
    /// <returns>Clinic procedures</returns>
    [HttpGet]
    public async Task<List<ProcedureGetDto>> GetClinicProcedure()
    {
        return await _clinicService.GetClinicProcedures();
    }
    
    /// <summary>
    ///     Get clinic procedures
    /// </summary>
    /// <returns>Clinic procedures</returns>
    [HttpGet("{procedure:Guid}")]
    public async Task<List<ProcedureGetDto>> GetClinicProcedureByGuid(Guid procedure)
    {
        return await _clinicService.GetClinicProcedureByGuid(procedure);
    }
    
    /// <summary>
    ///     Get clinic procedures
    /// </summary>
    /// <returns>Clinic procedures</returns>
    [Authorize(Role.Admin, Role.Clinic, Role.Professional)]
    [HttpPost]
    public async Task<List<ProcedureGetDto>> GetClinicProcedureByGuid(ProcedureGetDto procedure)
    {
        return await _clinicService.PutClinicProcedure(procedure);
    }
}