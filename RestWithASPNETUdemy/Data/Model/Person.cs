using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Data.Model;

[Table("Person")]
public class Person
{
    [Column("id")]
    public int Id { get; set; }
    [Required]
    [StringLength(60)]
    [Column("first_name")]    
    public string FirstName { get; set; } = "first_name";
    [Required]
    [StringLength(80)]
    [Column("last_name")]
    public string LastName { get; set; } = "last_name";
    [Required]
    [StringLength(100)]
    [Column("adress")]
    public string Adress { get; set; } = "adress";
    [Required]
    [Column("gender")]
    public char Gender { get; set; }
}