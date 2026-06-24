using Locatic.Models;
using Locatic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Locatic.Controllers;

public class BrandsController : Controller
{
    private readonly IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    public IActionResult Index()
    {
        var brands = _brandService.GetAll();
        return View(brands);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Brand brand)
    {
        if (!ModelState.IsValid)
            return View(brand);

        _brandService.Add(brand);
        return RedirectToAction(nameof(Index));
    }
}