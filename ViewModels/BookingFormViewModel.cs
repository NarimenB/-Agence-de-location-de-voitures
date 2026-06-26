using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Locatic.ViewModels;

public class BookingFormViewModel
{
    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int CarId { get; set; }

    [Required]
    public DateTime StartDate { get; set; } = DateTime.Today;

    [Required]
    public DateTime EndDate { get; set; } = DateTime.Today.AddDays(1);

    public SelectList? Customers { get; set; }
    public SelectList? Cars { get; set; }
}