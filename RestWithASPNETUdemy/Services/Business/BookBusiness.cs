using RestWithASPNETUdemy.Domain.Model;
using RestWithASPNETUdemy.Domain.Interfaces.Business;
using RestWithASPNETUdemy.Domain.Interfaces.Repository;
using RestWithASPNETUdemy.Domain.Entities;
using RestWithASPNETUdemy.Data.Mapping.Contract;
using RestWithASPNETUdemy.Hypermedia;

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

    public PagedSearchEntity<BookEntity> FindWithPagedSearch(
            string title,
            string sortDirection,
            int pageSize,
            int page)
    {
        var sort = (!string.IsNullOrWhiteSpace(sortDirection) &&
                    !sortDirection.Equals("desc")) ?
                    "asc" : "desc";
        var size = (pageSize < 1) ? 10 : pageSize;
        var offset = page > 0 ? (page - 1) * size : 0;
        string query = "Select * from book P Where 1 = 1 ";
        if (!string.IsNullOrWhiteSpace(title))
        {
            query += $"and p.title like '%{title}%' ";
        }
        query += $@"Order by p.title {sort}
                    Limit {size} offset {offset}";
        var countQuery = "Select count(*) from book P Where 1 = 1 ";
        if (!string.IsNullOrWhiteSpace(title))
        {
            countQuery += $"and p.title like '%{title}%' ";
        }

        var books = _repository.FindWithPagedSearch(query);
        int totalResults = _repository.GetCount(countQuery);
        return new PagedSearchEntity<BookEntity>
        {
            CurrentPage = page,
            List = _converter.Parse(books),
            PageSize = size,
            SortDirections = sort,
            TotalResults = totalResults
        };
    }


    public BookEntity FindByID(int id)
        => _converter.Parse(_repository.FindByID(id));

    public BookEntity Update(BookEntity book)
        => _converter.Parse(_repository.Update(_converter.Parse(book)));

    public BookEntity Create(BookEntity book)
        => _converter.Parse(_repository.Create(_converter.Parse(book)));

    public void Delete(int id)
        => _repository.Delete(id);
}
