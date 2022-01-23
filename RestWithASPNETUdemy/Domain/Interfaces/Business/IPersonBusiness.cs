using RestWithASPNETUdemy.Domain.Entities;

namespace RestWithASPNETUdemy.Domain.Interfaces.Business;

public interface IPersonBusiness{
    PersonEntity Create(PersonEntity person);
    PersonEntity FindByID(int id);
    IEnumerable<PersonEntity> FindByName(string firstName, string lastName);
    IEnumerable<PersonEntity> FindAll { get; }

    PersonEntity Update(PersonEntity person);
    PersonEntity Disable(int id);
    void Delete(int id);
}