using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Get(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            return Ok(AsDecimal(firstNumber) + AsDecimal(secondNumber));
        }
        return BadRequest("Invalid Input");
    }

    private string AsDecimal(string firstNumber)
    {
        throw new NotImplementedException();
    }

    private bool IsNumeric(string firstNumber)
    {
        throw new NotImplementedException();
    }
}
