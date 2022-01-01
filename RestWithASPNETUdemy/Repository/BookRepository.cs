using RestWithASPNETUdemy.Data.Context;
using RestWithASPNETUdemy.Data.Model;
using RestWithASPNETUdemy.Interfaces.Repository;

namespace RestWithASPNETUdemy.Repository;

public class BookRepository : IBaseRepository<Book>
{
    private MySQLContext _context;
    public BookRepository(MySQLContext context)
        => _context = context;

    public IEnumerable<Book> FindAll()
        => _context.Books.ToList();

    public Book FindByID(int id)
        => _context.Books.SingleOrDefault(p => p.Id == id);

    public void Update(Book book)
    {
        var _book = _context.Books.SingleOrDefault(p => p.Id == book.Id);
        if (_book != null)
        {
            try
            {
                _context.Entry(_book).CurrentValues.SetValues(book);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }

    public Book Create(Book book)
    {
        try
        {
            _context.Add(book);
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
        return book;
    }

    public void Delete(int id)
    {
        var _book = _context.Books.SingleOrDefault(p => p.Id == id);
        if (_book != null)
        {
            try
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
