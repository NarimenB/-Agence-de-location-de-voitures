using Locatic.Models;
using Locatic.Services.Interfaces;
using Locatic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Locatic.Controllers;

public class BookingsController : Controller
{
    private readonly IBookingService _bookingService;
    private readonly ICustomerService _customerService;
    private readonly ICarService _carService;

    public BookingsController(
        IBookingService bookingService,
        ICustomerService customerService,
        ICarService carService)
    {
        _bookingService = bookingService;
        _customerService = customerService;
        _carService = carService;
    }

    public IActionResult Index()
    {
        var bookings = _bookingService.GetAll();
        return View(bookings);
    }

    public IActionResult Create()
    {
        var viewModel = new BookingFormViewModel
        {
            Customers = new SelectList(_customerService.GetAll(), "Id", "LastName"),
            Cars = new SelectList(_carService.GetAll(), "Id", "LicensePlate")
        };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(BookingFormViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Customers = new SelectList(_customerService.GetAll(), "Id", "LastName");
            viewModel.Cars = new SelectList(_carService.GetAll(), "Id", "LicensePlate");
            return View(viewModel);
        }

        var booking = new Booking
        {
            CustomerId = viewModel.CustomerId,
            CarId = viewModel.CarId,
            StartDate = viewModel.StartDate,
            EndDate = viewModel.EndDate
        };

        bool success = _bookingService.Add(booking, out string error);

        if (!success)
        {
            ModelState.AddModelError(string.Empty, error);
            viewModel.Customers = new SelectList(_customerService.GetAll(), "Id", "LastName");
            viewModel.Cars = new SelectList(_carService.GetAll(), "Id", "LicensePlate");
            return View(viewModel);
        }

        return RedirectToAction(nameof(Index));
    }
}