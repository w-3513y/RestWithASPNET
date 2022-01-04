using RestWithASPNETUdemy.Data.Context;
using RestWithASPNETUdemy.Entities;
using RestWithASPNETUdemy.Interfaces.Repository;
using RestWithASPNETUdemy.Model;
using System.Security.Cryptography;
using System.Text;

namespace RestWithASPNETUdemy.Data.Repository;

public class UserRepository : IUserRepository
{
    private readonly MySQLContext _context;

    public UserRepository(MySQLContext context)
    {
        _context = context;
    }

    public User ValidateCredentials(UserEntity user)
    {
        var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
        return _context.Users.FirstOrDefault(p => (p.UserName == user.UserName) && (p.Password == pass));
    }

    public User ValidateCredentials(string userName) 
        => _context.Users.FirstOrDefault(p => p.UserName == userName);    

    public User RefreshUserInfo(User user)
    {
        var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));
        if (result != null)
        {
            try
            {
                _context.Entry(result).CurrentValues.SetValues(user);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        return result;
    }


    private string ComputeHash(string password, SHA256CryptoServiceProvider algorithm)
    {
        Byte[] inputBytes = Encoding.UTF8.GetBytes(password);
        Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
        return BitConverter.ToString(hashedBytes);
    }
}