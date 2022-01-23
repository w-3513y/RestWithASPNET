using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model;

[Table("Person")]
public class Person : Base
{
    [Column("first_name")]
    public string FirstName { get; set; } = "first_name";
    [Column("last_name")]
    public string LastName { get; set; } = "last_name";
    [Column("adress")]
    public string Adress { get; set; } = "adress";
    [Column("gender")]
    public char Gender { get; set; }
    [Column("enabled")]
    public bool Enabled { get; set; }
}