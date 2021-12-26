using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services;

public interface IPersonService{
    Person Create(Person person);
    Person FindByID(int id);
    List<Person> FindAll { get; }

    Person Update(Person person);
    void Delete(int id);
}