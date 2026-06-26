using Locatic.Data;
using Locatic.Models;
using Locatic.Services.Interfaces;

namespace Locatic.Services;

public class BrandService : IBrandService
{
    private readonly AppDbContext _context;

    public BrandService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Brand> GetAll() => _context.Brands.ToList();

    public Brand? GetById(int id) => _context.Brands.Find(id);

    public void Add(Brand brand)
    {
        _context.Brands.Add(brand);
        _context.SaveChanges();
    }
}