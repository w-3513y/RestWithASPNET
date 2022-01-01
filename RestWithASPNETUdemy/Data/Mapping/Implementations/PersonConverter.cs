using RestWithASPNETUdemy.Data.Mapping.Contract;
using RestWithASPNETUdemy.Data.ValueObjects;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Data.Mapping.Implementations;

public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
{
    public Person Parse(PersonVO Origem)
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

    public PersonVO Parse(Person Origem)
    {
        if (Origem == null) return null;
        return new PersonVO
        {
            Id = Origem.Id,
            FirstName = Origem.FirstName,
            LastName = Origem.LastName,
            Adress = Origem.Adress,
            Gender = Origem.Gender
        };

    }

    public IEnumerable<Person> Parse(IEnumerable<PersonVO> Origem)
        => Origem.Select(p => Parse(p)).ToArray();


    public IEnumerable<PersonVO> Parse(IEnumerable<Person> Origem)
        => Origem.Select(p => Parse(p)).ToArray();

}