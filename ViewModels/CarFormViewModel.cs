using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Locatic.ViewModels;

public class CarFormViewModel
{
    public int Id { get; set; }

    [Required]
    public string LicensePlate { get; set; } = string.Empty;

    [Required]
    public int Year { get; set; }

    [Required]
    public decimal DailyRate { get; set; }

    [Required]
    public int NumberOfSeats { get; set; }

    [Required]
    public string FuelType { get; set; } = string.Empty;

    [Required]
    public int CarModelId { get; set; }

    public SelectList? CarModels { get; set; }
}