using RestWithASPNETUdemy.Domain.Model;
using RestWithASPNETUdemy.Domain.Interfaces.Business;
using RestWithASPNETUdemy.Domain.Interfaces.Repository;
using RestWithASPNETUdemy.Domain.Entities;
using RestWithASPNETUdemy.Data.Mapping.Contract;
using RestWithASPNETUdemy.Hypermedia;

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


    public PagedSearchEntity<PersonEntity> FindWithPagedSearch(
        string name,
        string sortDirection, 
        int pageSize,
        int page)
    {
        var sort = (!string.IsNullOrWhiteSpace(sortDirection) &&
                    !sortDirection.Equals("desc")) ?
                    "asc" : "desc";
        var size = (pageSize < 1) ? 10 : pageSize;
        var offset = page > 0 ? (page - 1) * size : 0;
        string query = "Select * from person P Where 1 = 1 ";
        if (!string.IsNullOrWhiteSpace(name))
        {
            query += $"and p.first_name like '%{name}%' ";
        }
        query += $@"Order by p.first_name {sort}
                    Limit {size} offset {offset}";
        var countQuery = "Select count(*) from person P Where 1 = 1 ";
        if (!string.IsNullOrWhiteSpace(name))
        {
            countQuery += $"and p.first_name like '%{name}%' ";
        }

        var persons = _repository.FindWithPagedSearch(query);
        int totalResults = _repository.GetCount(countQuery);
        return new PagedSearchEntity<PersonEntity>
        {
            CurrentPage = page,
            List = _converter.Parse(persons),
            PageSize = size,
            SortDirections = sort,
            TotalResults = totalResults
        };
    }

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
