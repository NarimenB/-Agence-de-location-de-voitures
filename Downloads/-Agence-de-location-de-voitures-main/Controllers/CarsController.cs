using Locatic.Data;
using Locatic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Locatic.Controllers;

public class CarsController : Controller
{
    private readonly AppDbContext _context;

    public CarsController(AppDbContext context)
    {
        _context = context;
    }

    // list
    public async Task<IActionResult> Index()
    {
        var cars = await _context.Cars
            .Include(c => c.CarModel)
            .ThenInclude(m => m.Brand)
            .ToListAsync();

        return View(cars);
    }

    // Create GET
    public IActionResult Create()
    {
        ViewBag.CarModels = new SelectList(_context.CarModels, "Id", "Name");
        return View();
    }

    // Create POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Car car)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.CarModels = new SelectList(_context.CarModels, "Id", "Name");
            return View(car);
        }

        _context.Add(car);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null) return NotFound();

        ViewBag.CarModels = new SelectList(_context.CarModels, "Id", "Name", car.CarModelId);
        return View(car);
    }

    // EDIT POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Car car)
    {
        if (id != car.Id) return NotFound();

        if (!ModelState.IsValid)
        {
            ViewBag.CarModels = new SelectList(_context.CarModels, "Id", "Name", car.CarModelId);
            return View(car);
        }

        _context.Update(car);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // Suppresion get
    public async Task<IActionResult> Delete(int id)
    {
        var car = await _context.Cars
            .Include(c => c.CarModel)
            .ThenInclude(m => m.Brand)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (car == null) return NotFound();

        return View(car);
    }

    // Supression POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var car = await _context.Cars.FindAsync(id);

        if (car != null)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}