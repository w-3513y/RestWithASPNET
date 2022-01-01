namespace RestWithASPNETUdemy.Data.ValueObjects;

public class BookVO
{
    public int Id { get; set; }
    public string Author { get; set; } = "author";
    public DateTime Launch { get; set; }
    public decimal Price { get; set; }
    public string Title { get; set; } = "title";
}