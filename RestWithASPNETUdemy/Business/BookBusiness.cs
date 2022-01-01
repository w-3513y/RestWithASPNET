using RestWithASPNETUdemy.Data.Model;
using RestWithASPNETUdemy.Interfaces.Business;
using RestWithASPNETUdemy.Interfaces.Repository;

namespace RestWithASPNETUdemy.Business;

public class BookBusiness : IBookBusiness
{
    private readonly IBaseRepository<Book> _repository;

    public BookBusiness(IBaseRepository<Book> repository)
        => _repository = repository;

    public IEnumerable<Book> FindAll 
        => _repository.FindAll();

    public Book FindByID(int id)
        => _repository.FindByID(id);

    public void Update(Book book) 
        => _repository.Update(book);

    public Book Create(Book book) 
        => _repository.Create(book);

    public void Delete(int id) 
        => _repository.Delete(id);
}
