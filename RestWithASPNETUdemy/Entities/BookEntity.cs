using System.ComponentModel.DataAnnotations;

namespace RestWithASPNETUdemy.Data.Entities;

public class BookEntity
{
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Author { get; set; } = "author";
    [Required]
    public DateTime Launch { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    [StringLength(100)]
    public string Title { get; set; } = "title";
}