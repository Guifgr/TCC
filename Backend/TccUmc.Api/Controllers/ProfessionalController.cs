using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccUmc.Application.DTO.Clinic.Request;
using TccUmc.Application.DTO.Clinic.Response;
using TccUmc.Application.DTO.Professional;
using TccUmc.Application.IService;
using TccUmc.Domain.Enums;

namespace TccUmc.Api.Controllers;


[Authorize]
[Route("[controller]/[action]")]
public class ProfessionalController : Controller
{
    private readonly IClinicService _clinicService;

    public ProfessionalController(IClinicService clinicService)
    {
        _clinicService = clinicService;
    }

    [HttpPost]
    public Task<ProfessionalGetDto> CreateNewProfessional([FromBody]ProfessionalPostDto professional)
    {
        return _clinicService.CreateNewProfessional(professional);
    }
    [HttpGet]
    public Task<List<ProfessionalGetDto>> GetProfessionals()
    {
        return _clinicService.GetProfessionals();
    }
}