namespace CustomerX;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerAgeValidator _customerAgeValidator;

    public CustomerService(ICustomerRepository customerRepository, ICustomerAgeValidator customerAgeValidator)
    {
        _customerRepository = customerRepository;
        _customerAgeValidator = customerAgeValidator;
    }
    
    public void AddCustomer(CustomerEntity customer)
    {
        if (!_customerAgeValidator.IsOfLegalAge(customer.DateOfBirth))
        {
            throw new ArgumentException("Customer is not of legal age");
        }
        
        _customerRepository.AddCustomer(customer);
    }
    
    public List<CustomerEntity> GetAllCustomers()
    {
        return _customerRepository.GetAllCustomers();
    }
}