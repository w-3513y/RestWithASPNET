using RestWithASPNETUdemy.Data.Model;

namespace RestWithASPNETUdemy.Interfaces.Business;

public interface IPersonBusiness{
    Person Create(Person person);
    Person FindByID(int id);
    IEnumerable<Person> FindAll { get; }

    void Update(Person person);
    void Delete(int id);
}