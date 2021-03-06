using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Domain.Interfaces.Business;
using RestWithASPNETUdemy.Domain.Entities;
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
    public IActionResult Get(
        [FromQuery] string name,
        string sortDirection,
        int pageSize,
        int page) => Ok(_personBusiness.
                        FindWithPagedSearch(name,
                                            sortDirection,
                                            pageSize,
                                            page));

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

    [HttpGet("getbyName")]
    [ProducesResponseType((200), Type = typeof(PersonEntity))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult GetByName([FromQuery] string firstName,
                                   [FromQuery] string lastName)
    {
        var people = _personBusiness.FindByName(firstName, lastName);
        if (people == null) return NotFound();
        return Ok(people);
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

    [HttpPatch("patch")]
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