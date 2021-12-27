using RestWithASPNETUdemy.Data.Context;
using RestWithASPNETUdemy.Data.Model;
using RestWithASPNETUdemy.Interfaces.Business;
using RestWithASPNETUdemy.Interfaces.Repository;

namespace RestWithASPNETUdemy.Business;

public class PersonBusiness : IPersonBusiness
{
    private readonly IPersonRepository _repository;

    public PersonBusiness(IPersonRepository repository)
        => _repository = repository;

    public List<Person> FindAll 
        => _repository.FindAll();

    public Person FindByID(int id)
        => _repository.FindByID(id);

    public Person Update(Person person) 
        => _repository.Update(person);

    public Person Create(Person person) 
        => _repository.Create(person);

    public void Delete(int id) 
        => _repository.Delete(id);
}
