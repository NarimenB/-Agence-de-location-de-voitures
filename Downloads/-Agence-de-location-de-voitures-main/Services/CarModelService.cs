using Locatic.Data;
using Locatic.Models;
using Locatic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Locatic.Services;

public class CarModelService : ICarModelService
{
    private readonly AppDbContext _context;

    public CarModelService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<CarModel> GetAll() => _context.CarModels.Include(m => m.Brand).ToList();

    public CarModel? GetById(int id) => _context.CarModels.Include(m => m.Brand).FirstOrDefault(m => m.Id == id);

    public void Add(CarModel carModel)
    {
        _context.CarModels.Add(carModel);
        _context.SaveChanges();
    }
}