using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccUmc.Application.DTO.Consult;
using TccUmc.Application.DTO.Users.Request;
using TccUmc.Application.DTO.Users.Response;
using TccUmc.Application.IService;
using TccUmc.Domain.Enums;
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
    public async Task<IActionResult> CreateConsult([Required] [FromBody] ConsultPostDto consultPost)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var userId = HttpContext.GetHttpContextId();
        await _clinicService.CreateConsult(consultPost, userId);
        return Ok("Senha alterada com sucesso");
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
}