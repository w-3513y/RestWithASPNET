using RestWithASPNETUdemy.Entities;

namespace RestWithASPNETUdemy.Interfaces.Business;

public interface IBookBusiness{
    BookEntity Create(BookEntity book);
    BookEntity FindByID(int id);
    IEnumerable<BookEntity> FindAll { get; }
    BookEntity Update(BookEntity book);
    void Delete(int id);
}