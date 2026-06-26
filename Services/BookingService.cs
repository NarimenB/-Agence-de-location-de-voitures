using Locatic.Data;
using Locatic.Models;
using Locatic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Locatic.Services;

public class BookingService : IBookingService
{
    private readonly AppDbContext _context;

    public BookingService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Booking> GetAll()
    {
        return _context.Bookings
            .Include(b => b.Customer)
            .Include(b => b.Car)
                .ThenInclude(c => c.CarModel)
                    .ThenInclude(m => m.Brand)
            .ToList();
    }

    public Booking? GetById(int id)
    {
        return _context.Bookings
            .Include(b => b.Customer)
            .Include(b => b.Car)
                .ThenInclude(c => c.CarModel)
                    .ThenInclude(m => m.Brand)
            .FirstOrDefault(b => b.Id == id);
    }

    public bool Add(Booking booking, out string errorMessage)
    {
        errorMessage = string.Empty;

        if (booking.EndDate < booking.StartDate)
        {
            errorMessage = "La date de fin ne peut pas être avant la date de début.";
            return false;
        }

        bool carAlreadyBooked = _context.Bookings.Any(b =>
            b.CarId == booking.CarId &&
            booking.StartDate <= b.EndDate &&
            booking.EndDate >= b.StartDate
        );

        if (carAlreadyBooked)
        {
            errorMessage = "Cette voiture est déjà réservée sur cette période.";
            return false;
        }

        _context.Bookings.Add(booking);
        _context.SaveChanges();

        return true;
    }
}