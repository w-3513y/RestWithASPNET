using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model;

[Table("users")]
public class User : Base
{
    [Column("user_name")]
    public string UserName { get; set; } = "username";
    [Column("full_name")]
    public string FullName { get; set; } = "fullname";
    [Column("password")]
    public string Password { get; set; } = "password";
    [Column("refresch_token")]
    public string RefreshToken { get; set; } = "refreshtoken";
    [Column("refresh_token_expiry_time")]
    public DateTime RefreshTokenExpiryTime { get; set; }

}
