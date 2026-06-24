namespace Locatic.Models;

public class Car
{
    public int Id { get; set; }
    public string LicensePlate { get; set; } = string.Empty;
    public int Year { get; set; }
    public decimal DailyRate { get; set; }
    public int NumberOfSeats { get; set; }
    public string FuelType { get; set; } = string.Empty;

    public int CarModelId { get; set; }
    public CarModel CarModel { get; set; } = null!;

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}