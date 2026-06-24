using Locatic.Models;

namespace Locatic.Services.Interfaces;

public interface ICarModelService
{
    IEnumerable<CarModel> GetAll();
    CarModel? GetById(int id);
    void Add(CarModel carModel);
}