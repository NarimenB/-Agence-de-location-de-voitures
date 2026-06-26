using Locatic.Data;
using Locatic.Models;
using Locatic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Locatic.Services;

public class CarService : ICarService
{
    private readonly AppDbContext _context;

    public CarService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Car> GetAll() => 
        _context.Cars
            .Include(c => c.CarModel)
            .ThenInclude(m => m.Brand)
            .ToList();

    public Car? GetById(int id) => 
        _context.Cars
            .Include(c => c.CarModel)
            .ThenInclude(m => m.Brand)
            .FirstOrDefault(c => c.Id == id);

    public void Add(Car car)
    {
        _context.Cars.Add(car);
        _context.SaveChanges();
    }

    public void Update(Car car)
    {
        _context.Cars.Update(car);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var car = _context.Cars.Find(id);
        if (car != null)
        {
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }
    }
}