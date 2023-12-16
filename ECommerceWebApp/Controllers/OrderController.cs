using Microsoft.AspNetCore.Mvc;
using ECommerceWebApp.services;




public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    public IActionResult Index()
    {
        var allOrders = _orderService.GetAllOrders();
        return View(allOrders);
        
    }

    public IActionResult Create()
    {
        
        return View();
    }

    [HttpPost]
    public IActionResult Create(Order order)
    {
        if (ModelState.IsValid)
        {
            _orderService.PlaceOrder(order);
            return RedirectToAction("Index");
        }

        
        return View(order);
    }

    public IActionResult Edit(int id)
    {
        var order = _orderService.GetOrderById(id);

        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }

    [HttpPost]
    public IActionResult Edit(Order order)
    {
        if (ModelState.IsValid)
        {
            _orderService.UpdateOrder(order);
            return RedirectToAction("Index");
        }

        
        return View(order);
    }

    public IActionResult Delete(int id)
    {
        var order = _orderService.GetOrderById(id);

        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _orderService.CancelOrder(id);
        return RedirectToAction("Index");
    }
}


