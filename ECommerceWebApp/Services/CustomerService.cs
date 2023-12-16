public class CustomerService : ICustomerService
{
    private readonly MyDbContext _dbContext;

    public CustomerService(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        return _dbContext.Customers.ToList();
    }

    public Customer GetCustomerById(int customerId)
    {
        return _dbContext.Customers.FirstOrDefault();
    }

    public void AddCustomer(Customer customer)
    {
        _dbContext.Customers.Add(customer);
        _dbContext.SaveChanges();
    }

    public void UpdateCustomer(Customer customer)
    {
        var existingCustomer = _dbContext.Customers.Find(customer.Id);

        if (existingCustomer != null)
        {
            
            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Email = customer.Email;

            _dbContext.SaveChanges();
        }
    }

    public void DeleteCustomer(int customerId)
    {
        var customer = _dbContext.Customers.Find(customerId);

        if (customer != null)
        {
            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
        }
    }
}

