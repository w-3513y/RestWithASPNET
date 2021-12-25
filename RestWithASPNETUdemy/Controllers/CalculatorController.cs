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
            return Ok(
                $"{firstNumber} + {secondNumber} = {AsDecimal(firstNumber) + AsDecimal(secondNumber)}");
        }
        return BadRequest("Invalid Input");
    }
    private bool IsNumeric(string strNumber)
    {
        double number;
        return double.TryParse
            (strNumber,
            System.Globalization.NumberStyles.Any,
            System.Globalization.NumberFormatInfo.InvariantInfo,
            out number);
    }
    private decimal AsDecimal(string strNumber)
    {
        decimal decimalvalue;
        if (decimal.TryParse(strNumber, out decimalvalue))
        {
            return decimalvalue;
        }
        return 0;
    }


}
