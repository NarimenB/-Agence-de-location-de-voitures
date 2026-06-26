using Locatic.Models;

namespace Locatic.Services.Interfaces;

public interface IBrandService
{
    IEnumerable<Brand> GetAll();
    Brand? GetById(int id);
    void Add(Brand brand);
}