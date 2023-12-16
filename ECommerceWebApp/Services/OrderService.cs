public class OrderService : IOrderService
{
    private readonly MyDbContext _dbContext;

    public OrderService(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Order> GetAllOrders()
    {
        return _dbContext.Orders.ToList();
    }

    public Order GetOrderById(int orderId)
    {
        return _dbContext.Orders.FirstOrDefault(o => o.Id == orderId);
    }

    public void PlaceOrder(Order order)
    {
        _dbContext.Orders.Add(order);
        _dbContext.SaveChanges();
    }

    public void UpdateOrder(Order order)
    {
        var existingOrder = _dbContext.Orders.Find(order.Id);

        if (existingOrder != null)
        {
            
            existingOrder.CustomerId = order.CustomerId;
            existingOrder.TotalAmount = order.TotalAmount;

            _dbContext.SaveChanges();
        }
    }

    public void CancelOrder(int orderId)
    {
        var order = _dbContext.Orders.Find(orderId);

        if (order != null)
        {
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
        }
    }
}

