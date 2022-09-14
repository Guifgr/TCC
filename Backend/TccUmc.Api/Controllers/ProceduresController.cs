using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TccUmc.Application.DTO.Clinic.Request;
using TccUmc.Domain.Enums;

namespace TccUmc.Api.Controllers;

[Route("[controller]/[action]")]
public class ProceduresController : Controller
{
    public ProceduresController()
    {
    }

    /// <summary>
    ///     Update clinic information
    /// </summary>
    /// <returns>Clinic resumed data</returns>
    [Authorize(Role.Clinic, Role.Admin, Role.Professional)]
    [HttpPost]
    public string UpdateClinicData()
    {
        return "Passou";
    }
}