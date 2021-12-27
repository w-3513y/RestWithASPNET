using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Data.Model;

[Table("Person")]
public class Person
{    
    [Column("id")]
    public int Id { get; set; }
    [Column("first_name")]
    public string FirstName { get; set; } = "first_name";
    [Column("last_name")]
    public string LastName { get; set; } = "last_name";
    [Column("adress")]
    public string Adress { get; set; } = "adress";
    [Column("gender")]
    public char Gender { get; set; }
}