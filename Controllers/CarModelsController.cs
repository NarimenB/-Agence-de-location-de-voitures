using Locatic.Models;
using Locatic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Locatic.Controllers;

public class CarModelsController : Controller
{
    private readonly ICarModelService _carModelService;
    private readonly IBrandService _brandService;

    public CarModelsController(ICarModelService carModelService, IBrandService brandService)
    {
        _carModelService = carModelService;
        _brandService = brandService;
    }

    public IActionResult Index()
    {
        var models = _carModelService.GetAll();
        return View(models);
    }

    public IActionResult Create()
    {
        ViewBag.Brands = new SelectList(_brandService.GetAll(), "Id", "Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CarModel carModel)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Brands = new SelectList(_brandService.GetAll(), "Id", "Name");
            return View(carModel);
        }

        _carModelService.Add(carModel);
        return RedirectToAction(nameof(Index));
    }
}