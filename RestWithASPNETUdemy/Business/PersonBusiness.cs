using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Interfaces.Business;
using RestWithASPNETUdemy.Interfaces.Repository;
using RestWithASPNETUdemy.Data.Entities;
using RestWithASPNETUdemy.Data.Mapping.Contract;

namespace RestWithASPNETUdemy.Business;

public class PersonBusiness : IPersonBusiness
{
    private readonly IBaseRepository<Person> _repository;
    private readonly IParser<PersonEntity, Person> _converter;

    public PersonBusiness(IBaseRepository<Person> repository, IParser<PersonEntity, Person> converter)
    {
        _repository = repository;
        _converter = converter;
    }

    public IEnumerable<PersonEntity> FindAll
        => _converter.Parse(_repository.FindAll());

    public PersonEntity FindByID(int id)
        => _converter.Parse(_repository.FindByID(id));

    public PersonEntity Update(PersonEntity person)
        => _converter.Parse(_repository.Update(_converter.Parse(person)));

    public PersonEntity Create(PersonEntity person)
        => _converter.Parse(_repository.Create(_converter.Parse(person)));

    public void Delete(int id)
        => _repository.Delete(id);
}
