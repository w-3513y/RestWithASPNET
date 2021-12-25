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

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_personService.FindAll());
    }

    [HttpGet]
    public IActionResult GetById(int id)
    {
        var person = _personService.FindByID(id);
        if (person == null) return NotFound();
        return Ok(_personService.FindByID(id));
    }

    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
        if (person == null) return BadRequest();
        return Ok(_personService.Create(person));
    }

    [HttpPut]
    public IActionResult Update([FromBody] Person person)
    {
        if (person == null) return BadRequest();
        return Ok(_personService.Update(person));
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        _personService.Delete(id);
        return NoContent();
    }

}