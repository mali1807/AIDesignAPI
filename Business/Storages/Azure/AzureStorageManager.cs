using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Business.Storages.Abstract;
using Business.Storages.Concrete;
using Core.Configurations;
using Microsoft.AspNetCore.Http;
using File = Entities.Concrete.File;

namespace Business.Storages.Azure
{
    public class AzureStorageManager : Storage, IAzureStorageService
    {
        readonly BlobServiceClient _blobServiceClient;
        BlobContainerClient _blobContainerClient;
        public AzureStorageManager()
        {
            _blobServiceClient = new(OptionsConfiguration.Storages.Azure);
        }
        public async Task DeleteFileAsync(string containerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync();
        }

        public List<string> GetFilesName(string containerName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Select(blob => blob.Name).ToList();
        }

        public bool HasFile(string containerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Any(blob => blob.Name == fileName);
        }

        public async Task<List<File>> UploadAsync(string containerName, IFormFileCollection formFiles)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await _blobContainerClient.CreateIfNotExistsAsync();
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            List<File> datas = new();
            foreach (IFormFile file in formFiles)
            {
                string fileNewName = await FileRenameAsync(file.FileName);
                BlobClient blobClient = _blobContainerClient.GetBlobClient(fileNewName);
                await blobClient.UploadAsync(file.OpenReadStream());
                datas.Add(new() { Name = fileNewName, Path = $"{containerName}/{fileNewName}" });
            }
            return datas;
        }
    }
}
