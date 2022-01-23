using RestWithASPNETUdemy.Domain.Entities;
using RestWithASPNETUdemy.Domain.Interfaces.Business;

namespace RestWithASPNETUdemy.Services.Business;

public class FileBusiness : IFileBusiness
{
    private readonly string _basePath;
    private readonly IHttpContextAccessor _context;


    public FileBusiness(IHttpContextAccessor context)
    {
        _context = context;
        _basePath = Directory.GetCurrentDirectory() + "//UploadDir//";
    }
    public byte[] GetFile(string fileName)
    {
        throw new NotImplementedException();
    }

    public async Task<FileDetailEntity> SaveFileToDisk(IFormFile file)
    {
        var fileDetail = new FileDetailEntity();
        var fileType = Path.GetExtension(file.FileName);
        var baseUrl = _context.HttpContext.Request.Host;
        if (fileType.ToLower() == ".pdf" ||
            fileType.ToLower() == ".jpg" ||
            fileType.ToLower() == ".png" ||
            fileType.ToLower() == ".jpeg")
        {
            var docName = Path.GetFileName(file.FileName);
            if (file != null && file.Length > 0)
            {
                var destination = Path.Combine(_basePath, "", docName);
                fileDetail.DocumentName = docName;
                fileDetail.DocType = fileType;
                fileDetail.DocUrl = Path.Combine(_basePath + "/api/file/v1" + fileDetail.DocumentName);
                
                using var stream = new FileStream(destination, FileMode.Create);
                await file.CopyToAsync(stream);
            }
        }
        return fileDetail;
    }


    public Task<IEnumerable<FileDetailEntity>> SaveFilesToDisk(IEnumerable<IFormFile> files)
    {
        throw new NotImplementedException();
    }
}