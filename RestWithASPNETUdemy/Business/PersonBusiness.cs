using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Interfaces.Business;
using RestWithASPNETUdemy.Interfaces.Repository;
using RestWithASPNETUdemy.Data.ValueObjects;
using RestWithASPNETUdemy.Data.Mapping.Implementations;

namespace RestWithASPNETUdemy.Business;

public class PersonBusiness : IPersonBusiness
{
    private readonly IBaseRepository<Person> _repository;
    private readonly PersonConverter _converter;

    public PersonBusiness(IBaseRepository<Person> repository, PersonConverter converter)
    {
        _repository = repository;
        _converter = converter;
    }

    public IEnumerable<PersonVO> FindAll
        => _converter.Parse(_repository.FindAll());

    public PersonVO FindByID(int id)
        => _converter.Parse(_repository.FindByID(id));

    public PersonVO Update(PersonVO person)
        => _converter.Parse(_repository.Update(_converter.Parse(person)));

    public PersonVO Create(PersonVO person)
        => _converter.Parse(_repository.Create(_converter.Parse(person)));

    public void Delete(int id)
        => _repository.Delete(id);
}
