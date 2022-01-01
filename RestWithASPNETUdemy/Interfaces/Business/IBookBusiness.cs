using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Interfaces.Business;

public interface IBookBusiness{
    Book Create(Book book);
    Book FindByID(int id);
    IEnumerable<Book> FindAll { get; }
    Book Update(Book book);
    void Delete(int id);
}