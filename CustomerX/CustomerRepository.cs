using System.Diagnostics.CodeAnalysis;

namespace CustomerX;

[ExcludeFromCodeCoverage]
public class CustomerRepository: ICustomerRepository
{
    private readonly List<CustomerEntity> _customerEntities = new();

    public void AddCustomer(CustomerEntity customerEntity)
    {
        _customerEntities.Add(customerEntity);
    }

    public List<CustomerEntity> GetAllCustomers()
    {
        return _customerEntities;
    }
}
