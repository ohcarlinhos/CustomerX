using CustomerX;
using FluentAssertions;
using Moq;

namespace UnitTests;

public class CustomerServiceTests
{
    private readonly Mock<ICustomerRepository> _customerRepositoryMock;
    private readonly Mock<ICustomerAgeValidator> _customerAgeValidatorMock;

    public CustomerServiceTests()
    {
        _customerRepositoryMock = new Mock<ICustomerRepository>();
        _customerAgeValidatorMock = new Mock<ICustomerAgeValidator>();
    }

    [Fact]
    public void Given_Customer_When_IsNotOfLegalAge_Then_ShouldThrowException()
    {
        // Arrange
        var customer = new CustomerEntity("Maria", DateTime.Now);
        var customerService = new CustomerService(_customerRepositoryMock.Object, _customerAgeValidatorMock.Object);

        _customerAgeValidatorMock
            .Setup(v => v.IsOfLegalAge(customer.DateOfBirth))
            .Returns(false);

        // Act
        Action action = () => customerService.AddCustomer(customer);

        // Assert
        action.Should().Throw<ArgumentException>();
        _customerRepositoryMock.Verify(r => r.AddCustomer(customer), Times.Never);
    }
    
    [Fact]
    public void Given_Customer_When_IsOfLegalAge_Then_ShouldAddCustomer()
    {
        // Arrange
        var customer = new CustomerEntity("Maria", DateTime.Now.AddYears(-50));
        var customerService = new CustomerService(_customerRepositoryMock.Object, _customerAgeValidatorMock.Object);

        _customerAgeValidatorMock
            .Setup(v => v.IsOfLegalAge(customer.DateOfBirth))
            .Returns(true);

        // Act
        customerService.AddCustomer(customer);

        // Assert
        _customerRepositoryMock.Verify(r => r.AddCustomer(customer), Times.Once);
    }
}