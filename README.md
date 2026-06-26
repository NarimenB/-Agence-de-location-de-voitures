# Locatic — Car Rental Agency

A web application built with ASP.NET Core MVC to manage a small car rental agency: 
its catalog, customers, and bookings.

## Project Description
Locatic allows a car rental agency to manage its fleet of vehicles, register customers, 
and handle bookings. Each car belongs to a model (e.g. Clio, 208, Series 3), and each 
model is made by a brand (e.g. Renault, Peugeot, BMW). The agency can record customers 
and the bookings they make on specific cars.

All data is stored in a SQLite database powered by Entity Framework Core, 
and survives server restarts.

## Group Members
- Narimen Boumaout — Data layer, models, database, brands & car models
- Melyssa Bertille— Cars & customers CRUD
-  Dihya Ouchene— Bookings & business rules

## Tech Stack
- ASP.NET Core MVC (.NET 8)
- Entity Framework Core 8
- SQLite
- Bootstrap 5

## Project Structure
- `Models/` — Domain entities (Brand, CarModel, Car, Customer, Booking)
- `Data/` — AppDbContext and migrations
- `Services/` — Business logic layer
- `Services/Interfaces/` — Service interfaces
- `Controllers/` — MVC controllers
- `Views/` — Razor views

## Features
- Brands: list and add
- Car Models: list and add (linked to a brand)
- Cars: full CRUD
- Customers: create and list
- Bookings: create with availability validation

## How to Run
1. Clone the repository
2. Go to the `Locatic` folder
3. Run `dotnet ef database update`
4. Run `dotnet run`
5. Open `http://localhost:5207`
