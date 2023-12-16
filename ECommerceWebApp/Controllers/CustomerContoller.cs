using Microsoft.AspNetCore.Mvc;
using ECommerceWebApp.services;



public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public IActionResult Index()
    {
        var allCustomers = _customerService.GetAllCustomers();
        return View(allCustomers);
    }

    public IActionResult Create()
    {
        
        return View();
    }

    [HttpPost]
    public IActionResult Create(Customer customer)
    {
        if (ModelState.IsValid)
        {
            _customerService.AddCustomer(customer);
            return RedirectToAction("Index");
        }

        
        return View(customer);
    }

    public IActionResult Edit(int id)
    {
        var customer = _customerService.GetCustomerById(id);

        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }

    [HttpPost]
    public IActionResult Edit(Customer customer)
    {
        if (ModelState.IsValid)
        {
            _customerService.UpdateCustomer(customer);
            return RedirectToAction("Index");
        }

        
        return View(customer);
    }

    public IActionResult Delete(int id)
    {
        var customer = _customerService.GetCustomerById(id);

        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _customerService.DeleteCustomer(id);
        return RedirectToAction("Index");
    }
}


