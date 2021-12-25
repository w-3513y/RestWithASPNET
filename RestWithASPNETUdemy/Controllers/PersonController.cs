using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public PersonController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum")]
    public IActionResult Sum()
    {
        return BadRequest("Invalid Input");
    }


}