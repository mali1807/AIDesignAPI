using Microsoft.AspNetCore.Http;
using Business.Storages.Abstract;
using File = Entities.Concrete.File;

namespace Business.Storages.Concrete
{
    public class StorageManager : IStorageService
    {
        private readonly IStorage _storage;
        public StorageManager(IStorage storage)
        {
            _storage = storage;
        }
        public string StorageType => _storage.GetType().Name;

        public Task DeleteFileAsync(string pathOrContainerName, string fileName)
        {
            return _storage.DeleteFileAsync(pathOrContainerName, fileName);
        }

        public List<string> GetFilesName(string pathOrContainerName)
        {
            return _storage.GetFilesName(pathOrContainerName);
        }

        public bool HasFile(string pathOrContainerName, string fileName)
        {
            return _storage.HasFile(pathOrContainerName, fileName);
        }

        public Task<List<File>> UploadAsync(string pathOrContainerName, IFormFileCollection formFiles)
        {
            return _storage.UploadAsync(pathOrContainerName, formFiles);
        }
    }
}
