using RestWithASPNETUdemy.Domain.Model;
using RestWithASPNETUdemy.Domain.Interfaces.Business;
using RestWithASPNETUdemy.Domain.Interfaces.Repository;
using RestWithASPNETUdemy.Domain.Entities;
using RestWithASPNETUdemy.Data.Mapping.Contract;

namespace RestWithASPNETUdemy.Services.Business;

public class PersonBusiness : IPersonBusiness
{
    private readonly IPersonRepository _repository;
    private readonly IParser<PersonEntity, Person> _converter;

    public PersonBusiness(IPersonRepository repository, IParser<PersonEntity, Person> converter)
    {
        _repository = repository;
        _converter = converter;
    }

    public IEnumerable<PersonEntity> FindAll
        => _converter.Parse(_repository.FindAll());

    public PersonEntity FindByID(int id)
        => _converter.Parse(_repository.FindByID(id));


    public IEnumerable<PersonEntity> FindByName(
        string firstName,
        string lastName) 
        => _converter.Parse(_repository.findByName(firstName, lastName));
    public PersonEntity Update(PersonEntity person)
        => _converter.Parse(_repository.Update(_converter.Parse(person)));

    public PersonEntity Create(PersonEntity person)
        => _converter.Parse(_repository.Create(_converter.Parse(person)));

    public PersonEntity Disable(int id)
    {
        var person = _repository.Disable(id);
        return _converter.Parse(person);
    }

    public void Delete(int id)
        => _repository.Delete(id);
}
