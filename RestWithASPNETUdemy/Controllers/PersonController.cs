using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Interfaces.Business;
using RestWithASPNETUdemy.Entities;
using RestWithASPNETUdemy.Hypermedia.Filters;
using Microsoft.AspNetCore.Authorization;

namespace RestWithASPNETUdemy.Controllers;

[ApiVersion("1")]
[ApiController]
[Authorize("Bearer")]
[Route("api/[controller]/v{version:apiversion}")]
public class PersonController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;
    private IPersonBusiness _personBusiness;

    public PersonController(
        ILogger<CalculatorController> logger,
        IPersonBusiness personBusiness)
    {
        _logger = logger;
        _personBusiness = personBusiness;
    }

    [HttpGet("get")]
    [ProducesResponseType((200), Type = typeof(List<PersonEntity>))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get()
    {
        return Ok(_personBusiness.FindAll);
    }

    [HttpGet("getbyId")]
    [ProducesResponseType((200), Type = typeof(PersonEntity))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult GetById(int id)
    {
        var person = _personBusiness.FindByID(id);
        if (person == null) return NotFound();
        return Ok(person);
    }

    [HttpPost("post")]
    [ProducesResponseType((200), Type = typeof(PersonEntity))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Post([FromBody] PersonEntity person)
    {
        if (person == null) return BadRequest();
        return Ok(_personBusiness.Create(person));
    }

    [HttpPut("update")]
    [ProducesResponseType((200), Type = typeof(PersonEntity))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Update([FromBody] PersonEntity person)
    {
        if (person == null) return BadRequest();
        return Ok(_personBusiness.Update(person));
    }

    [HttpGet("patch")]
    [ProducesResponseType((200), Type = typeof(List<PersonEntity>))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Patch(int id)
    {
        var person = _personBusiness.Disable(id);
        return Ok(person);
    }

    [HttpDelete("delete")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult Delete(int id)
    {
        _personBusiness.Delete(id);
        return NoContent();
    }

}