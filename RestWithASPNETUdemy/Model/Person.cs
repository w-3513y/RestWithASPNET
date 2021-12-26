using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model;

[Table("person")]
public class Person
{    
    [Column("id")]
    public int Id { get; set; }
    [Column("first_name")]
    public string FirstName { get; set; }
    [Column("last_name")]
    public string LastName { get; set; }
    [Column("adress")]
    public string Adress { get; set; }
    [Column("gender")]
    public char Gender { get; set; }
}