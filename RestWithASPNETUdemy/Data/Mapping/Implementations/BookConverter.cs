using RestWithASPNETUdemy.Data.Mapping.Contract;
using RestWithASPNETUdemy.Data.ValueObjects;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Data.Mapping.Implementations;

public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
{
    public Book Parse(BookVO Origem)
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

    public BookVO Parse(Book Origem)
    {
        if (Origem == null) return null;
        return new BookVO
        {
            Id = Origem.Id,
            Author = Origem.Author,
            Launch = Origem.Launch,
            Price = Origem.Price,
            Title = Origem.Title
        };

    }

    public IEnumerable<Book> Parse(List<BookVO> Origem)
        => Origem.Select(p => Parse(p)).ToArray();


    public IEnumerable<BookVO> Parse(List<Book> Origem)
        => Origem.Select(p => Parse(p)).ToArray();

}