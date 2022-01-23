using RestWithASPNETUdemy.Domain.Entities;
using RestWithASPNETUdemy.Domain.Model;

namespace RestWithASPNETUdemy.Domain.Interfaces.Repository;

public interface IUserRepository
{
    User ValidateCredentials(UserEntity user);
    User ValidateCredentials(string userName);
    bool RevokeToken(string userName);
    User RefreshUserInfo(User user);
}