using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Data.Context;

public class MySQLContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public MySQLContext(DbContextOptions<MySQLContext> options)
    : base(options)
    {
    }


}