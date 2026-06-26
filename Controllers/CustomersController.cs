using Locatic.Models;
using Locatic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Locatic.Controllers;

public class CustomersController : Controller
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public IActionResult Index()
    {
        var customers = _customerService.GetAll();
        return View(customers);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Customer customer)
    {
        if (!ModelState.IsValid)
            return View(customer);

        _customerService.Add(customer);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var customer = _customerService.GetById(id);
        if (customer == null) return NotFound();
        return View(customer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Customer customer)
    {
        if (!ModelState.IsValid)
            return View(customer);

        customer.Id = id;
        _customerService.Update(customer);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var customer = _customerService.GetById(id);
        if (customer == null) return NotFound();
        return View(customer);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _customerService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}