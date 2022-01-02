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

}