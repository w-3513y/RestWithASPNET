using Microsoft.EntityFrameworkCore;

namespace RestWithASPNETUdemy.Model.Context;

public class MySQLContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public MySQLContext(DbContextOptions<MySQLContext> options)
    : base(options)
    {
    }

    protected MySQLContext()
    {
    }


}