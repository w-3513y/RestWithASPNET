using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Domain.Model;

[Table("books")]
public class Book : Base
{
    [Column("author")]
    public string Author { get; set; } = "author";
    [Column("launch_date")]
    public DateTime Launch { get; set; }
    [Column("price")]
    public decimal Price { get; set; }
    [Column("title")]
    public string Title { get; set; } = "title";
}