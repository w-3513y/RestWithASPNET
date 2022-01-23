using System.Security.Claims;

namespace RestWithASPNETUdemy.Interfaces.Services;

public interface ITokenService{
    string GenerateAccessToken(IEnumerable<Claim> claims);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}