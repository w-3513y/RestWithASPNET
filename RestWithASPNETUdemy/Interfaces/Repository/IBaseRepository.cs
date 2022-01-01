using RestWithASPNETUdemy.Data.Model;

namespace RestWithASPNETUdemy.Interfaces.Repository;

public interface IBaseRepository<TEntity> where TEntity : class
{
    TEntity Create(TEntity obj);
    TEntity FindByID(int id);
    IEnumerable<TEntity> FindAll ();
    void Update(TEntity obj);
    void Delete(int id);
}