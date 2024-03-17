using Microsoft.AspNetCore.Http;
using File = Entities.Concrete.File;

namespace Business.Storages.Abstract
{
    public interface IStorage
    {
        Task<List<File>> UploadAsync(string pathOrContainerName, IFormFileCollection formFiles);
        Task DeleteFileAsync(string pathOrContainerName, string fileName);
        List<string> GetFilesName(string pathOrContainerName);
        bool HasFile(string pathOrContainerName, string fileName);
    }
}
