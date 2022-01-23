using System.Security.Claims;

namespace RestWithASPNETUdemy.Domain.Interfaces.Services;

public interface ITokenService{
    string GenerateAccessToken(IEnumerable<Claim> claims);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}