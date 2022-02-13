using RestWithASPNETUdemy.Domain.Entities;
using RestWithASPNETUdemy.Hypermedia;

namespace RestWithASPNETUdemy.Domain.Interfaces.Business;

public interface IBookBusiness
{
    BookEntity Create(BookEntity book);
    BookEntity FindByID(int id);
    IEnumerable<BookEntity> FindAll { get; }
    public PagedSearchEntity<BookEntity> FindWithPagedSearch(
        string name,
        string sortDirection,
        int pageSize,
        int page);
    BookEntity Update(BookEntity book);
    void Delete(int id);
}