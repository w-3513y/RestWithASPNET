namespace RestWithASPNETUdemy.Data.Entities;

public class PersonEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "first_name";
    public string LastName { get; set; } = "last_name";
    public string Adress { get; set; } = "adress";
    public char Gender { get; set; }
}