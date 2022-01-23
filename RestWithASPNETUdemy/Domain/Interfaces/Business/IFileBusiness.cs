using RestWithASPNETUdemy.Domain.Entities;

namespace RestWithASPNETUdemy.Domain.Interfaces.Business;

public interface IFileBusiness
{
    public byte[] GetFile(string fileName);
    public Task<FileDetailEntity> SaveFileToDisk(IFormFile file);
    public Task<IEnumerable<FileDetailEntity>> SaveFilesToDisk(IEnumerable<IFormFile> files);

 }