using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EugeneCV.Models;
using EugeneCV.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace EugeneCV.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICVManagementService _cvManagementService;

    public HomeController(ILogger<HomeController> logger, ICVManagementService cVManagementService)
    {
        _logger = logger;
        _cvManagementService = cVManagementService;
    }

    [Authorize(Policy = "AdminOrUser")]
    public async Task<IActionResult> Index()
    {
        var cv = await _cvManagementService.GetCVAsync();
        return View(cv);
    }
    [Authorize(Policy = "AdminOrUser")]
    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Login");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
