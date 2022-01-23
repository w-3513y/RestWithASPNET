using System.ComponentModel.DataAnnotations;
using RestWithASPNETUdemy.Hypermedia;
using RestWithASPNETUdemy.Hypermedia.Abstract;

namespace RestWithASPNETUdemy.Domain.Entities;

public class BookEntity : ISupportsHyperMedia
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
    public List<HyperMediaLink> Links { get ;set;} = new List<HyperMediaLink>();
}