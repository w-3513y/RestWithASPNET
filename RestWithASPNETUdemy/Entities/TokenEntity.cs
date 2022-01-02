namespace RestWithASPNETUdemy.Entities;

public class TokenEntity {
    public TokenEntity(bool authenticated,
                       string created,
                       string expiration,
                       string acessToken,
                       string refreshToken)
    {
        Authenticated = authenticated;
        Created = created;
        Expiration = expiration;
        AcessToken = acessToken;
        RefreshToken = refreshToken;
    }

    public bool Authenticated {get;set;}
    public string Created { get; set; } = "created";
    public string Expiration { get; set; } = "expiration";
    public string  AcessToken { get; set; } = "acessToken";
    public string RefreshToken { get; set; } = "refreshToken";
}
