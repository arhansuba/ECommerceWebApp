public interface ICustomerService
{
    IEnumerable<Customer> GetAllCustomers();
    Customer GetCustomerById(int customerId);
    void AddCustomer(Customer customer);
    void UpdateCustomer(Customer customer);
    void DeleteCustomer(int customerId);
}

