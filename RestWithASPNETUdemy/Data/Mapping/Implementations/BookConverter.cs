using RestWithASPNETUdemy.Data.Mapping.Contract;
using RestWithASPNETUdemy.Domain.Entities;
using RestWithASPNETUdemy.Domain.Model;

namespace RestWithASPNETUdemy.Data.Mapping.Implementations;

public class BookConverter : IParser<BookEntity, Book>
{
    public Book Parse(BookEntity Origem)
    {
        if (Origem == null) return null;
        return new Book
        {
            Id = Origem.Id,
            Author = Origem.Author,
            Launch = Origem.Launch,
            Price = Origem.Price,
            Title = Origem.Title
        };
    }

    public BookEntity Parse(Book Origem)
    {
        if (Origem == null) return null;
        return new BookEntity
        {
            Id = Origem.Id,
            Author = Origem.Author,
            Launch = Origem.Launch,
            Price = Origem.Price,
            Title = Origem.Title
        };

    }

    public IEnumerable<Book> Parse(IEnumerable<BookEntity> Origem)
        => Origem.Select(p => Parse(p)).ToArray();


    public IEnumerable<BookEntity> Parse(IEnumerable<Book> Origem)
        => Origem.Select(p => Parse(p)).ToArray();

}