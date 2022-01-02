using System.ComponentModel.DataAnnotations;
using RestWithASPNETUdemy.Hypermedia;
using RestWithASPNETUdemy.Hypermedia.Abstract;

namespace RestWithASPNETUdemy.Entities;

public class PersonEntity : ISupportsHyperMedia
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
    public List<HyperMediaLink> Links { get ;set;} = new List<HyperMediaLink>();
}