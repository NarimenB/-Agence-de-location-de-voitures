using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Locatic.Models;

namespace Locatic.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<CarModel> CarModels => Set<CarModel>();
    public DbSet<Car> Cars => Set<Car>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Booking> Bookings => Set<Booking>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>().HasData(
            new Brand { Id = 1, Name = "Renault", CountryOfOrigin = "France" },
            new Brand { Id = 2, Name = "Peugeot", CountryOfOrigin = "France" },
            new Brand { Id = 3, Name = "BMW", CountryOfOrigin = "Germany" }
        );

        modelBuilder.Entity<CarModel>().HasData(
            new CarModel { Id = 1, Name = "Clio", BrandId = 1 },
            new CarModel { Id = 2, Name = "208", BrandId = 2 },
            new CarModel { Id = 3, Name = "Series 3", BrandId = 3 }
        );

        modelBuilder.Entity<Car>().HasData(
            new Car { Id = 1, LicensePlate = "AB-123-CD", Year = 2021, DailyRate = 45, NumberOfSeats = 5, FuelType = "Petrol", CarModelId = 1 },
            new Car { Id = 2, LicensePlate = "EF-456-GH", Year = 2022, DailyRate = 50, NumberOfSeats = 5, FuelType = "Diesel", CarModelId = 2 },
            new Car { Id = 3, LicensePlate = "IJ-789-KL", Year = 2023, DailyRate = 90, NumberOfSeats = 5, FuelType = "Electric", CarModelId = 3 }
        );

        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, LastName = "Dupont", FirstName = "Jean", Email = "jean@dupont.fr", Phone = "0601020304" },
            new Customer { Id = 2, LastName = "Martin", FirstName = "Sophie", Email = "sophie@martin.fr" }
        );
    }
}

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite("Data Source=locatic.db");

        return new AppDbContext(optionsBuilder.Options);
    }
}