namespace CustomerX;

public class CustomerAgeValidator: ICustomerAgeValidator
{
    private const int EighteenYearsInDays =  6570;
    
    public bool IsOfLegalAge(DateTime birthDate)
    {
        var today = DateTime.Now;
        var age = today - birthDate;
        return age.TotalDays >= EighteenYearsInDays;
    }
}
