namespace Locatic.Models;

public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? CountryOfOrigin { get; set; }

    public ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
}