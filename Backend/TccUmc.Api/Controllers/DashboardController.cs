using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccUmc.Application.DTO;
using TccUmc.Application.IService;
using TccUmc.Utility.Extensions;

namespace TccUmc.Api.Controllers;

[Authorize]
[Route("[controller]/[action]")]
public class DashbardController : Controller
{
    private readonly IDashboardService _dashboardService;

    public DashbardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    /// <summary>
    ///     Change password
    /// </summary>
    /// <param name="userDto">User Information</param>
    /// <returns>User email</returns>
    [AllowAnonymous]
    //[ApiExplorerSettings(IgnoreApi = true)]
    [HttpGet]
    public async Task<DashboardGetDto> GetDashboardInfo()
    {
        return await _dashboardService.GetDashboard(HttpContext.GetHttpContextId());
    }
}