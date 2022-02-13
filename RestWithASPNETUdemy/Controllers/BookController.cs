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
public class BookController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;
    private IBookBusiness _bookBusiness;

    public BookController(
        ILogger<CalculatorController> logger,
        IBookBusiness bookBusiness)
    {
        _logger = logger;
        _bookBusiness = bookBusiness;
    }

    [HttpGet("get")]
    [ProducesResponseType((200), Type = typeof(List<BookEntity>))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get(
        [FromQuery] string title,
        string sortDirection,
        int pageSize,
        int page) => Ok(_bookBusiness.
                        FindWithPagedSearch(title,
                                            sortDirection,
                                            pageSize,
                                            page));

    [HttpGet("getbyId")]
    [ProducesResponseType((200), Type = typeof(BookEntity))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult GetById(int id)
    {
        var book = _bookBusiness.FindByID(id);
        if (book == null) return NotFound();
        return Ok(book);
    }

    [HttpPost("post")]
    [ProducesResponseType((200), Type = typeof(BookEntity))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Post([FromBody] BookEntity book)
    {
        if (book == null) return BadRequest();
        return Ok(_bookBusiness.Create(book));
    }

    [HttpPut("update")]
    [ProducesResponseType((200), Type = typeof(BookEntity))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Update([FromBody] BookEntity book)
    {
        if (book == null) return BadRequest();
        _bookBusiness.Update(book);
        return NoContent();

    }

    [HttpDelete("delete")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult Delete(int id)
    {
        _bookBusiness.Delete(id);
        return NoContent();
    }

}