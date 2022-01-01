using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Interfaces.Business;

namespace RestWithASPNETUdemy.Controllers;

[ApiVersion("1")]
[ApiController]
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
    public IActionResult Get()
    {
        return Ok(_bookBusiness.FindAll);
    }

    [HttpGet("getbyId")]
    public IActionResult GetById(int id)
    {
        var book = _bookBusiness.FindByID(id);
        if (book == null) return NotFound();
        return Ok(book);
    }

    [HttpPost("post")]
    public IActionResult Post([FromBody] Book book)
    {
        if (book == null) return BadRequest();
        return Ok(_bookBusiness.Create(book));
    }

    [HttpPut("update")]
    public IActionResult Update([FromBody] Book book)
    {
        if (book == null) return BadRequest();
        _bookBusiness.Update(book);
        return NoContent();

    }

    [HttpDelete("delete")]
    public IActionResult Delete(int id)
    {
        _bookBusiness.Delete(id);
        return NoContent();
    }

}