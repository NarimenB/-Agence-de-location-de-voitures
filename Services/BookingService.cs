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

    public IEnumerable<Booking> GetAll() =>
        _context.Bookings
            .Include(b => b.Customer)
            .Include(b => b.Car)
                .ThenInclude(c => c.CarModel)
                    .ThenInclude(m => m.Brand)
            .ToList();

    public Booking? GetById(int id) =>
        _context.Bookings
            .Include(b => b.Customer)
            .Include(b => b.Car)
                .ThenInclude(c => c.CarModel)
                    .ThenInclude(m => m.Brand)
            .FirstOrDefault(b => b.Id == id);

    public bool Add(Booking booking, out string error)
    {
        // Rule 1: end date must be after start date
        if (booking.EndDate <= booking.StartDate)
        {
            error = "End date must be after start date.";
            return false;
        }

        // Rule 2: car must not already be booked on that period
        bool overlap = _context.Bookings.Any(b =>
            b.CarId == booking.CarId &&
            b.StartDate < booking.EndDate &&
            b.EndDate > booking.StartDate);

        if (overlap)
        {
            error = "This car is already booked for the selected period.";
            return false;
        }

        _context.Bookings.Add(booking);
        _context.SaveChanges();
        error = string.Empty;
        return true;
    }
}