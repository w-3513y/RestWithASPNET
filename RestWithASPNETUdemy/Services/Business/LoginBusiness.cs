using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using RestWithASPNETUdemy.Configurations;
using RestWithASPNETUdemy.Domain.Entities;
using RestWithASPNETUdemy.Domain.Interfaces.Business;
using RestWithASPNETUdemy.Domain.Interfaces.Repository;
using RestWithASPNETUdemy.Domain.Interfaces.Services;

namespace RestWithASPNETUdemy.Services.Business;

public class LoginBusiness : ILoginBusiness
{
    private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
    private TokenConfiguration _tokenConfiguration;
    private IUserRepository _repository;
    private readonly ITokenService _tokenService;

    public LoginBusiness(
        TokenConfiguration tokenConfiguration,
        IUserRepository repository,
        ITokenService tokenService)
    {
        _tokenConfiguration = tokenConfiguration;
        _repository = repository;
        _tokenService = tokenService;
    }

    public TokenEntity ValidateCredentials(UserEntity userCredentials)
    {
        var user = _repository.ValidateCredentials(userCredentials);
        if (user == null)
        {
            return null;
        }
        var claims = new List<Claim> {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
        };
        var accessToken = _tokenService.GenerateAccessToken(claims);
        var refreshToken = _tokenService.GenerateRefreshToken();
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_tokenConfiguration.DaysToExpiry);
        _repository.RefreshUserInfo(user);
        DateTime createDate = DateTime.Now;
        DateTime expirationDate = createDate.AddMinutes(_tokenConfiguration.Minutes);

        return new TokenEntity(
            true,
            createDate.ToString(DATE_FORMAT),
            expirationDate.ToString(DATE_FORMAT),
            accessToken,
            refreshToken);
    }

    public TokenEntity ValidateCredentials(TokenEntity token)
    {
        var accessToken = token.AcessToken;
        var refreshToken = token.RefreshToken;
        var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
        var userName = principal.Identity.Name;
        var user = _repository.ValidateCredentials(userName);
        if (user == null ||
            user.RefreshToken != refreshToken ||
            user.RefreshTokenExpiryTime <= DateTime.Now)
        {
            return null;
        }
        accessToken = _tokenService.GenerateAccessToken(principal.Claims);
        refreshToken = _tokenService.GenerateRefreshToken();
        user.RefreshToken = refreshToken;

        _repository.RefreshUserInfo(user);
        DateTime createDate = DateTime.Now;
        DateTime expirationDate = createDate.AddMinutes(_tokenConfiguration.Minutes);

        return new TokenEntity(
            true,
            createDate.ToString(DATE_FORMAT),
            expirationDate.ToString(DATE_FORMAT),
            accessToken,
            refreshToken);
    }

    public bool RevokeToken(string userName) 
        => _repository.RevokeToken(userName);
}
