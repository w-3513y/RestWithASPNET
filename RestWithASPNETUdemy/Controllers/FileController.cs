using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Domain.Entities;
using RestWithASPNETUdemy.Domain.Interfaces.Business;

namespace RestWithASPNETUdemy.Controllers;


[ApiVersion("1")]
[ApiController]
[Authorize("Bearer")]
[Route("api/[controller]/v{version:apiversion}")]
public class FileController : ControllerBase
{
    private readonly IFileBusiness _fileBusiness;

    public FileController(IFileBusiness fileBusiness)
    {
        _fileBusiness = fileBusiness;
    }

    [HttpPost("uploadFile")]
    [ProducesResponseType((200), Type = typeof(FileDetailEntity))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [Produces("application/json")]
    public async Task<IActionResult> UploadOneFile([FromForm] IFormFile file)
    {
        var detail = await _fileBusiness.SaveFileToDisk(file);
        return new OkObjectResult(detail);
    }
}