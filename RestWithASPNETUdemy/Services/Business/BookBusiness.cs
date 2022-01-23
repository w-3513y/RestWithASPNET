using RestWithASPNETUdemy.Domain.Model;
using RestWithASPNETUdemy.Domain.Interfaces.Business;
using RestWithASPNETUdemy.Domain.Interfaces.Repository;
using RestWithASPNETUdemy.Domain.Entities;
using RestWithASPNETUdemy.Data.Mapping.Contract;

namespace RestWithASPNETUdemy.Services.Business;

public class BookBusiness : IBookBusiness
{
    private readonly IBaseRepository<Book> _repository;
    private readonly IParser<BookEntity, Book> _converter;

    public BookBusiness(IBaseRepository<Book> repository, IParser<BookEntity, Book> converter)
    {
        _repository = repository;
        _converter = converter;
    }

    public IEnumerable<BookEntity> FindAll
        => _converter.Parse(_repository.FindAll());

    public BookEntity FindByID(int id)
        => _converter.Parse(_repository.FindByID(id));

    public BookEntity Update(BookEntity book)
        => _converter.Parse(_repository.Update(_converter.Parse(book)));

    public BookEntity Create(BookEntity book)
        => _converter.Parse(_repository.Create(_converter.Parse(book)));

    public void Delete(int id)
        => _repository.Delete(id);
}
