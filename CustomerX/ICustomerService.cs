namespace CustomerX;

public interface ICustomerService
{
    void AddCustomer(CustomerEntity customer);
    List<CustomerEntity> GetAllCustomers();
}