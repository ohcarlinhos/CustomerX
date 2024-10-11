namespace CustomerX;

public interface ICustomerAgeValidator
{
    bool IsOfLegalAge(DateTime birthDate);
}