namespace Locatic.Models;

public class Customer
{
    public int Id { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}