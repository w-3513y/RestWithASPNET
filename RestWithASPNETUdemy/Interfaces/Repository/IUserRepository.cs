using RestWithASPNETUdemy.Entities;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Interfaces.Repository;

public interface IUserRepository
{
    User ValidateCredentials(UserEntity user);
    User ValidateCredentials(string userName);
    User RefreshUserInfo(User user);
}