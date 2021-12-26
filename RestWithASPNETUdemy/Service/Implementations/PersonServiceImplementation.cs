using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementations;

public class PersonServiceImplementation : IPersonService
{    

    public Person Create(Person person) => person;

    public void Delete(long id)
    {
    }

    public List<Person> FindAll()
    {
        var people = new List<Person>();        
        for (int i = 0; i < 8; i++){
            people.Add(FindByID(i));
        }
        return people;
    }

    public Person FindByID(long id)
    {
        return new Person
        {
            Id = id,
            FirstName = $"Name{id}",
            LastName = $"LastName{id}",
            Adress = $"Adress{id} - UF",
            Gender = 'G'
        };
    }

    public Person Update(Person person) => person;
}
