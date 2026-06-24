using Locatic.Models;

namespace Locatic.Services.Interfaces;

public interface ICarService
{
    IEnumerable<Car> GetAll();
    Car? GetById(int id);
    void Add(Car car);
    void Update(Car car);
    void Delete(int id);
}