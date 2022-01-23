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
    public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
    {
        var detail = await _fileBusiness.SaveFileToDisk(file);
        return new OkObjectResult(detail);
    }

    [HttpPost("uploadFiles")]
    [ProducesResponseType((200), Type = typeof(IEnumerable<FileDetailEntity>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [Produces("application/json")]
    public async Task<IActionResult> UploadFiles([FromForm] IEnumerable<IFormFile> files)
    {
        var details = await _fileBusiness.SaveFilesToDisk(files);
        return new OkObjectResult(details);
    }

    [HttpPost("downloadFile")]
    [ProducesResponseType((200), Type = typeof(byte[]))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [Produces("application/octet-stream")]
    public async Task<IActionResult> DownloadFile(string fileName)
    {
        byte[] buffer = _fileBusiness.GetFile(fileName);
        if (buffer != null)
        {
            HttpContext
            .Response
            .ContentType = 
            $"application/{Path.GetExtension(fileName).Replace(".", "")}";
            HttpContext
            .Response
            .Headers
            .Add("content-length", buffer.Length.ToString());
            await HttpContext
                 .Response
                 .Body
                 .WriteAsync(buffer, 0, buffer.Length);
        }
        return new ContentResult();
    }


}