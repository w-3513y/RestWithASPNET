using RestWithASPNETUdemy.Domain.Model;

namespace RestWithASPNETUdemy.Domain.Interfaces.Repository;

public interface IBaseRepository<T> where T : Base
{
    T Create(T obj);
    T FindByID(int id);
    IEnumerable<T> FindAll ();
    T Update(T obj);
    void Delete(int id);
    IEnumerable<T> FindWithPagedSearch(string query);
    int GetCount(string query);
}