using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Domain.Model;

public class Base
{
    [Required]
    [Key]
    [Column("id")]
    public int Id { get; set; }
}
