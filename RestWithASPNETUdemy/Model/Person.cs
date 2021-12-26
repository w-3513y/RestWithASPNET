using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Model;

public class Person
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Adress { get; set; }
    public char Gender { get; set; }
}