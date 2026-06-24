using Locatic.Models;

namespace Locatic.Services.Interfaces;

public interface IBookingService
{
    IEnumerable<Booking> GetAll();
    Booking? GetById(int id);
    bool Add(Booking booking, out string error);
}