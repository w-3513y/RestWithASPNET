using RestWithASPNETUdemy.Data.Model;

namespace RestWithASPNETUdemy.Interfaces.Business;

public interface IBookBusiness{
    Book Create(Book book);
    Book FindByID(int id);
    IEnumerable<Book> FindAll { get; }
    void Update(Book book);
    void Delete(int id);
}