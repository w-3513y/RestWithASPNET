using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Data.Context;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Interfaces.Repository;

namespace RestWithASPNETUdemy.Data.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : Base
{
    private MySQLContext _context;
    private DbSet<T> dataset;
    public BaseRepository(MySQLContext context)
    {
        _context = context;
        dataset = _context.Set<T>();
    }

    public IEnumerable<T> FindAll()
        => dataset.ToList();

    public T FindByID(int id)
        => dataset.SingleOrDefault(p => p.Id.Equals(id));

    public T Update(T obj)
    {
        var result = dataset.SingleOrDefault(p => p.Id.Equals(obj.Id));
        if (result != null)
        {
            try
            {
                _context.Entry(result).CurrentValues.SetValues(obj);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        return result;
    }

    public T Create(T obj)
    {
        try
        {
            dataset.Add(obj);
            _context.SaveChanges();
            return obj;
        }
        catch
        {
            throw;
        }
    }

    public void Delete(int id)
    {
        var result = dataset.SingleOrDefault(p => p.Id == id);
        if (result != null)
        {
            try
            {
                dataset.Remove(result);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
