using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Sum(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            return Ok(
                $"{firstNumber} + {secondNumber} = {AsDecimal(firstNumber) + AsDecimal(secondNumber)}");
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
    public IActionResult Subtraction(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            return Ok(
                $"{firstNumber} - {secondNumber} = {AsDecimal(firstNumber) + AsDecimal(secondNumber)}");
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
    public IActionResult Multiplication(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            return Ok(
                $"{firstNumber} * {secondNumber} = {AsDecimal(firstNumber) + AsDecimal(secondNumber)}");
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("division/{firstNumber}/{secondNumber}")]
    public IActionResult Division(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            return Ok(
                $"{firstNumber} / {secondNumber} = {AsDecimal(firstNumber) + AsDecimal(secondNumber)}");
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("mean")] //body Example: ["12", "13", "14"]
    public IActionResult Mean([FromBody] IEnumerable<string> strNumbers)
    {
        /*inf: FromBody in swagger throw the exception:
          TypeError: Window.fetch: HEAD or GET Request cannot have a body.
          you can avoid this using FromQuery*/
        var sumNumbers = 0m;
        foreach (var number in strNumbers)
        {
            if (IsNumeric(number))
            {
                sumNumbers += AsDecimal(number);
            }
            else
            {
                return BadRequest($"Invalid Input: {number}");
            }
        };
        return Ok($"{sumNumbers / strNumbers.Count()}");
    }

    [HttpGet("squareroot/{number}")]
    public IActionResult SquareRoot(string number)
    {
        if (IsNumeric(number))
        {
            var square = SquareRoot(AsDecimal(number));
            if (square == AsDecimal(number))
            {
                return BadRequest($"There's no rational value to square root of {number}");
            }
            return Ok($"{square}");
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

    private decimal SquareRoot(decimal number)
    {        
        var (sqrnumber, factor, atempts) = (1m, 2, 1);
        do
        {
            if (number % factor == 0)
            {
                number /= factor;
                if (atempts % 2 != 0)
                {
                    sqrnumber *= factor;
                }
                atempts++;
            }
            else
            {
                factor++;
            }
        } while (number > 1);
        return sqrnumber;
    }


}
