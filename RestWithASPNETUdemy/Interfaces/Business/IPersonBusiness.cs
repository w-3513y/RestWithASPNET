using RestWithASPNETUdemy.Data.Model;

namespace RestWithASPNETUdemy.Interfaces.Business;

public interface IPersonBusiness{
    Person Create(Person person);
    Person FindByID(int id);
    List<Person> FindAll { get; }

    Person Update(Person person);
    void Delete(int id);
}