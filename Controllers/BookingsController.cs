using Locatic.Data;
using Locatic.Models;
using Locatic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Locatic.Controllers;

public class BookingsController : Controller
{
    private readonly IBookingService _bookingService;
    private readonly AppDbContext _context;

    public BookingsController(IBookingService bookingService, AppDbContext context)
    {
        _bookingService = bookingService;
        _context = context;
    }

    public IActionResult Index()
    {
        var bookings = _bookingService.GetAll();
        return View(bookings);
    }

    public IActionResult Create()
    {
        LoadSelectLists();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Booking booking)
    {
        ModelState.Remove("Customer");
        ModelState.Remove("Car");

        if (!ModelState.IsValid)
        {
            LoadSelectLists();
            return View(booking);
        }

        bool success = _bookingService.Add(booking, out string error);

        if (!success)
        {
            ModelState.AddModelError(string.Empty, error);
            LoadSelectLists();
            return View(booking);
        }

        return RedirectToAction(nameof(Index));
    }

    private void LoadSelectLists()
    {
        var customers = _context.Customers
            .OrderBy(c => c.LastName)
            .ToList()
            .Select(c => new
            {
                c.Id,
                FullName = $"{c.FirstName} {c.LastName}"
            });

        var cars = _context.Cars
            .Include(c => c.CarModel)
                .ThenInclude(m => m.Brand)
            .OrderBy(c => c.LicensePlate)
            .ToList()
            .Select(c => new
            {
                c.Id,
                Label = $"{c.LicensePlate} - {c.CarModel.Brand.Name} {c.CarModel.Name}"
            });

        ViewBag.Customers = new SelectList(customers, "Id", "FullName");
        ViewBag.Cars = new SelectList(cars, "Id", "Label");
    }
}