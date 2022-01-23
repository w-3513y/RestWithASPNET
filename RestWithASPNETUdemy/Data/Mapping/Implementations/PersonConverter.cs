using RestWithASPNETUdemy.Data.Mapping.Contract;
using RestWithASPNETUdemy.Domain.Entities;
using RestWithASPNETUdemy.Domain.Model;

namespace RestWithASPNETUdemy.Data.Mapping.Implementations;

public class PersonConverter : IParser<PersonEntity, Person>
{
    public Person Parse(PersonEntity Origem)
    {
        if (Origem == null) return null;
        return new Person
        {
            Id = Origem.Id,
            FirstName = Origem.FirstName,
            LastName = Origem.LastName,
            Adress = Origem.Adress,
            Gender = Origem.Gender
        };
    }

    public PersonEntity Parse(Person Origem)
    {
        if (Origem == null) return null;
        return new PersonEntity
        {
            Id = Origem.Id,
            FirstName = Origem.FirstName,
            LastName = Origem.LastName,
            Adress = Origem.Adress,
            Gender = Origem.Gender
        };

    }

    public IEnumerable<Person> Parse(IEnumerable<PersonEntity> Origem)
        => Origem.Select(p => Parse(p)).ToArray();


    public IEnumerable<PersonEntity> Parse(IEnumerable<Person> Origem)
        => Origem.Select(p => Parse(p)).ToArray();

}