using Locatic.Models;
using Locatic.Services.Interfaces;
using Locatic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Locatic.Controllers;

public class CarsController : Controller
{
    private readonly ICarService _carService;
    private readonly ICarModelService _carModelService;

    public CarsController(ICarService carService, ICarModelService carModelService)
    {
        _carService = carService;
        _carModelService = carModelService;
    }

    public IActionResult Index()
    {
        var cars = _carService.GetAll();
        return View(cars);
    }

    public IActionResult Details(int id)
    {
        var car = _carService.GetById(id);
        if (car == null) return NotFound();
        return View(car);
    }

    public IActionResult Create()
    {
        var viewModel = new CarFormViewModel
        {
            CarModels = new SelectList(_carModelService.GetAll(), "Id", "Name")
        };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CarFormViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.CarModels = new SelectList(_carModelService.GetAll(), "Id", "Name");
            return View(viewModel);
        }

        var car = new Car
        {
            LicensePlate = viewModel.LicensePlate,
            Year = viewModel.Year,
            DailyRate = viewModel.DailyRate,
            NumberOfSeats = viewModel.NumberOfSeats,
            FuelType = viewModel.FuelType,
            CarModelId = viewModel.CarModelId
        };

        _carService.Add(car);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var car = _carService.GetById(id);
        if (car == null) return NotFound();

        var viewModel = new CarFormViewModel
        {
            Id = car.Id,
            LicensePlate = car.LicensePlate,
            Year = car.Year,
            DailyRate = car.DailyRate,
            NumberOfSeats = car.NumberOfSeats,
            FuelType = car.FuelType,
            CarModelId = car.CarModelId,
            CarModels = new SelectList(_carModelService.GetAll(), "Id", "Name")
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, CarFormViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.CarModels = new SelectList(_carModelService.GetAll(), "Id", "Name");
            return View(viewModel);
        }

        var car = new Car
        {
            Id = id,
            LicensePlate = viewModel.LicensePlate,
            Year = viewModel.Year,
            DailyRate = viewModel.DailyRate,
            NumberOfSeats = viewModel.NumberOfSeats,
            FuelType = viewModel.FuelType,
            CarModelId = viewModel.CarModelId
        };

        _carService.Update(car);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var car = _carService.GetById(id);
        if (car == null) return NotFound();
        return View(car);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _carService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}