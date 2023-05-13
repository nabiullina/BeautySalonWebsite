using System.Diagnostics;
using BeautySalon.Data;
using BeautySalon.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BeautysalonContext _beautySalonContext;

    public HomeController(ILogger<HomeController> logger, BeautysalonContext beautySalonContext)
    {
        _logger = logger;
        _beautySalonContext = beautySalonContext;
    }

    public IActionResult Index()
    {
        var services = _beautySalonContext.Services.ToList();
        return View(services);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View();
    }
}