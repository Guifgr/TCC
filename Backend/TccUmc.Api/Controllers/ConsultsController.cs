using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccUmc.Application.DTO.Consult;
using TccUmc.Application.DTO.Users.Request;
using TccUmc.Application.DTO.Users.Response;
using TccUmc.Application.IService;
using TccUmc.Domain.Enums;
using TccUmc.Domain.Exceptions;
using TccUmc.Domain.Models;
using TccUmc.Utility.Extensions;

namespace TccUmc.Api.Controllers;

[Authorize]
[Route("[controller]/[action]")]
public class ConsultsController : Controller
{
    private readonly IClinicService _clinicService;

    public ConsultsController(IClinicService clinicService)
    {
        _clinicService = clinicService;
    }

    /// <summary>
    /// Create a consultPost for the user
    /// </summary>
    /// <returns>Consute creation or note</returns>
    [HttpPost]
    public async Task<ConsultPostDto> CreateConsult([Required] [FromBody] ConsultPostDto consultPost)
    {
        if (!ModelState.IsValid)
        {
            throw new BadRequestException(ModelState.ToString());
        }
        var userId = HttpContext.GetHttpContextId();
        return await _clinicService.CreateConsult(consultPost, userId);
    }
    
    /// <summary>
    /// Create a consultPost for the user
    /// </summary>
    /// <returns>Consute creation or note</returns>
    [HttpPost("{UserGuid:guid}")]
    public async Task<ConsultPostDto> ClinicCreateConsult([Required] [FromBody] ConsultPostDto consultPost, Guid UserGuid)
    {
        if (!ModelState.IsValid)
        {
            throw new BadRequestException(ModelState.ToString());
        }
        
        return await _clinicService.CreateConsultClinic(consultPost, UserGuid);
    }
    
    /// <summary>
    /// Get the user consults
    /// </summary>
    /// <returns>A list of user consults</returns>
    [HttpGet]
    public async Task<List<ConsultGetDto>> GetUserConsults()
    {
        var userId = HttpContext.GetHttpContextId();
        return await _clinicService.GetUserConsults(userId);
    }
    
    /// <summary>
    /// Get the user consults
    /// </summary>
    /// <returns>A list of user consults</returns>
    [Authorize(Role.Clinic)]
    [HttpGet]
    public async Task<List<ConsultGetDto>> GetClinicConsults()
    {
        var userId = HttpContext.GetHttpContextId();
        return await _clinicService.GetClincConsults(userId);
    }
    
    /// <summary>
    /// Get the user consults
    /// </summary>
    /// <returns>A list of user consults</returns>
    [Authorize(Role.User)]
    [HttpDelete("{ConsultGuid:guid}")]
    public IActionResult DeleteConsult(Guid ConsultGuid)
    {
        var userId = HttpContext.GetHttpContextId();
        _clinicService.DeleteConsult(ConsultGuid, userId);
        return Ok("Deletado com sucesso");
    }
    
    /// <summary>
    /// Get the user consults
    /// </summary>
    /// <returns>A list of user consults</returns>
    [Authorize(Role.Clinic)]
    [HttpDelete("{ConsultGuid:guid}")]
    public IActionResult DeleteConsultClinic(Guid ConsultGuid)
    {
        var userId = HttpContext.GetHttpContextId();
        _clinicService.DeleteConsultClinic(ConsultGuid);
        return Ok("Deletado com sucesso");
    }
}