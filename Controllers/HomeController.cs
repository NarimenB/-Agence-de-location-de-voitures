using Locatic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Locatic.Controllers;

public class HomeController : Controller
{
    private readonly IBrandService _brandService;

    public HomeController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    public IActionResult Index()
    {
        var brands = _brandService.GetAll();
        return View(brands);
    }

    public IActionResult Privacy()
    {
        return View();
    }
}