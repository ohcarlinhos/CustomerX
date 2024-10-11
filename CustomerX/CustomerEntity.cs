namespace CustomerX;

public class CustomerEntity
{
    public CustomerEntity(string name, DateTime dateOfBirth)
    {
        Name = name;
        DateOfBirth = dateOfBirth;
    }
    
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
}