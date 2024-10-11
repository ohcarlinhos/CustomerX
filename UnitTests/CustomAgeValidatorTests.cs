using CustomerX;
using FluentAssertions;

namespace UnitTests;

public class CustomAgeValidatorTests
{
    [Fact]
    public void Given_BirthDate_When_IsNotOfLegalAge_Then_ShouldReturnFalse()
    {
        // Arrange
        var birthDate = DateTime.Now;
        var customerAgeValidator = new CustomerAgeValidator();

        // Act
        var ofLegalAge = customerAgeValidator.IsOfLegalAge(birthDate);

        // Assert
        ofLegalAge.Should().BeFalse();
    }
    
    [Fact]
    public void Given_BirthDate_When_IsOfLegalAge_Then_ShouldReturnTrue()
    {
        // Arrange
        var birthDate = DateTime.Now.AddYears(-18);
        var customerAgeValidator = new CustomerAgeValidator();

        // Act
        var ofLegalAge = customerAgeValidator.IsOfLegalAge(birthDate);

        // Assert
        ofLegalAge.Should().BeTrue();
    }
}