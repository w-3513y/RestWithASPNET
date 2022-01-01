using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Interfaces.Repository;

public interface IBaseRepository<T> where T : Base
{
    T Create(T obj);
    T FindByID(int id);
    IEnumerable<T> FindAll ();
    T Update(T obj);
    void Delete(int id);
}