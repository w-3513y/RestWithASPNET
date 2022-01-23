using RestWithASPNETUdemy.Entities;

namespace RestWithASPNETUdemy.Interfaces.Business;

public interface ILoginBusiness
{
    public TokenEntity ValidateCredentials(UserEntity user);
    public TokenEntity ValidateCredentials(TokenEntity token);
    public bool RevokeToken(string userName);
}