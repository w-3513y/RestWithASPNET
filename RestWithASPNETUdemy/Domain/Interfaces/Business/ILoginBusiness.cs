using RestWithASPNETUdemy.Domain.Entities;

namespace RestWithASPNETUdemy.Domain.Interfaces.Business;

public interface ILoginBusiness
{
    public TokenEntity ValidateCredentials(UserEntity user);
    public TokenEntity ValidateCredentials(TokenEntity token);
    public bool RevokeToken(string userName);
}