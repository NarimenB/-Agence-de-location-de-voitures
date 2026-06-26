using Locatic.Data;
using Locatic.Models;
using Locatic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Locatic.Services;

public class CustomerService : ICustomerService
{
    private readonly AppDbContext _context;

    public CustomerService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Customer> GetAll()
    {
        return _context.Customers.ToList();
    }

    public Customer? GetById(int id)
    {
        return _context.Customers
            .Include(c => c.Bookings)
            .FirstOrDefault(c => c.Id == id);
    }

    public void Add(Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
    }

    public void Update(Customer customer)
    {
        _context.Customers.Update(customer);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var customer = _context.Customers.Find(id);

        if (customer == null)
        {
            return;
        }

        _context.Customers.Remove(customer);
        _context.SaveChanges();
    }
}