using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Services.Implementations;

public class PersonServiceImplementation : IPersonService
{
    private MySQLContext _context;
    public PersonServiceImplementation(MySQLContext context) 
        => _context = context;

    public Person Create(Person person) => person;

    public void Delete(int id)
    {
    }

    public List<Person> FindAll 
        => _context.People.ToList();

    public Person FindByID(int id)
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
