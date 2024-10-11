namespace CustomerX;

public interface ICustomerRepository
{
    void AddCustomer(CustomerEntity customerEntity);
    List<CustomerEntity> GetAllCustomers();
}