using RestWithASPNETUdemy.Data.Model;

namespace RestWithASPNETUdemy.Interfaces.Repository;

public interface IPersonRepository
{
    Person Create(Person person);
    Person FindByID(int id);
    List<Person> FindAll ();

    Person Update(Person person);
    void Delete(int id);
}