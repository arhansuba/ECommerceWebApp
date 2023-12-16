public interface IOrderService
{
    IEnumerable<Order> GetAllOrders();
    Order GetOrderById(int orderId);
    void PlaceOrder(Order order);
    void UpdateOrder(Order order);
    void CancelOrder(int orderId);
}

