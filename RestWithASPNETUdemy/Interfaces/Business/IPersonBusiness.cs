using RestWithASPNETUdemy.Entities;

namespace RestWithASPNETUdemy.Interfaces.Business;

public interface IPersonBusiness{
    PersonEntity Create(PersonEntity person);
    PersonEntity FindByID(int id);
    IEnumerable<PersonEntity> FindAll { get; }

    PersonEntity Update(PersonEntity person);
    PersonEntity Disable(int id);
    void Delete(int id);
}