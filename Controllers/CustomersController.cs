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
        {
            return View(customer);
        }

        _customerService.Add(customer);
        return RedirectToAction(nameof(Index));
    }
}