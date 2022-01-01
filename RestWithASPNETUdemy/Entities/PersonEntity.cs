using System.ComponentModel.DataAnnotations;

namespace RestWithASPNETUdemy.Data.Entities;

public class PersonEntity
{
    public int Id { get; set; }
    [Required]
    [StringLength(60)]
    public string FirstName { get; set; } = "first_name";
    [Required]
    [StringLength(80)]
    public string LastName { get; set; } = "last_name";
    [Required]
    [StringLength(100)]
    public string Adress { get; set; } = "adress";
    [Required]
    public char Gender { get; set; }
}