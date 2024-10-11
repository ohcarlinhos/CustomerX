namespace CustomerX;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            var maria = new CustomerEntity("maria", DateTime.Now.AddYears(-20));
            var joao = new CustomerEntity("joao", DateTime.Now.AddYears(-22));
            var pedro = new CustomerEntity("pedro", DateTime.Now.AddYears(-17));

            var customerRepository = new CustomerRepository();
            var customerAgeValidator = new CustomerAgeValidator();

            var customerService = new CustomerService(customerRepository, customerAgeValidator);

            customerService.AddCustomer(maria);
            customerService.AddCustomer(joao);

            var customers = customerService.GetAllCustomers();
            customers.ForEach(c => Console.WriteLine($"Cliente: {c}"));

            customerService.AddCustomer(pedro);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}