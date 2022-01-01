using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model;

public class Base
{
    [Required]
    [Column("id")]
    public int Id { get; set; }
}
