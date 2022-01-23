using RestWithASPNETUdemy.Domain.Model;

namespace RestWithASPNETUdemy.Domain.Interfaces.Repository;

public interface IPersonRepository : IBaseRepository<Person>
{
    Person Disable(int id);
    IEnumerable<Person> findByName(string firstName, string lastName);
}