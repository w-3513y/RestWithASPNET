using RestWithASPNETUdemy.Entities;

namespace RestWithASPNETUdemy.Interfaces.Business;

public interface ILoginBusiness
{
    public TokenEntity ValidateCredentials(UserEntity user);
}