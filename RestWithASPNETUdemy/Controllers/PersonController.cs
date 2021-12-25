using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;
    private IPersonService _personService;

    public PersonController(
        ILogger<CalculatorController> logger,
        IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet("get")]
    public IActionResult Get()
    {
        return Ok(_personService.FindAll());
    }

    [HttpGet("getbyId")]
    public IActionResult GetById(int id)
    {
        var person = _personService.FindByID(id);
        if (person == null) return NotFound();
        return Ok(person);
    }

    [HttpPost("post")]
    public IActionResult Post([FromBody] Person person)
    {
        if (person == null) return BadRequest();
        return Ok(_personService.Create(person));
    }

    [HttpPut("update")]
    public IActionResult Update([FromBody] Person person)
    {
        if (person == null) return BadRequest();
        return Ok(_personService.Update(person));
    }

    [HttpDelete("delete")]
    public IActionResult Delete(int id)
    {
        _personService.Delete(id);
        return NoContent();
    }

}