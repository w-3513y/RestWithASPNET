using RestWithASPNETUdemy.Data.ValueObjects;

namespace RestWithASPNETUdemy.Interfaces.Business;

public interface IPersonBusiness{
    PersonVO Create(PersonVO person);
    PersonVO FindByID(int id);
    IEnumerable<PersonVO> FindAll { get; }

    PersonVO Update(PersonVO person);
    void Delete(int id);
}