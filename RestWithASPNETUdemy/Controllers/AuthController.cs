using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Interfaces.Business;
using RestWithASPNETUdemy.Entities;
using RestWithASPNETUdemy.Hypermedia.Filters;

namespace RestWithASPNETUdemy.Controllers;

[ApiVersion("1")]
[Route("api/[controller]/v{version:apiversion}")]
[ApiController]
public class AuthController : ControllerBase
{
    private ILoginBusiness _loginbusiness;

    public AuthController(ILoginBusiness loginbusiness)
    {
        _loginbusiness = loginbusiness;
    }

    [HttpPost]
    [Route("signin")]
    public IActionResult Signin([FromBody] UserEntity user)
    {
        if (user == null)
        {
            return BadRequest("Invalid client request");
        }
        var token = _loginbusiness.ValidateCredentials(user);
        if (token == null)
        {
            return Unauthorized();
        }
        return Ok(token);
    }

    [HttpPost]
    [Route("refresh")]
    public IActionResult Refresh([FromBody] TokenEntity tokenEntity)
    {
        if (tokenEntity == null)
        {
            return BadRequest("Invalid client request");
        }
        var token = _loginbusiness.ValidateCredentials(tokenEntity);
        if (token == null)
        {
            return BadRequest("Invalid client request");
        }
        return Ok(token);
    }
}