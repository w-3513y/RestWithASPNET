namespace RestWithASPNETUdemy.Data.ValueObjects;

public class PersonVO
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "first_name";
    public string LastName { get; set; } = "last_name";
    public string Adress { get; set; } = "adress";
    public char Gender { get; set; }
}