using AutoMapper;
using Business.Abstract;
using Business.DTOs.Requests.Images;
using Business.DTOs.Responses.Images;
using Business.Storages.Abstract;
using Core.DataAccess.Paging;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Entities.Concrete.File;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;
        private readonly IFileRepository _fileRepository;

        public ImageManager(IImageRepository imageRepository, IMapper mapper, IStorageService storageService, IFileRepository fileRepository)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
            _storageService = storageService;
            _fileRepository = fileRepository;
        }

        public async Task<List<UploadImageResponse>> UploadImageAsync(UploadImageRequest uploadImageRequest)
        {
            var files = await _storageService.UploadAsync("images", uploadImageRequest.Files);
            List<UploadImageResponse> response = new();
            foreach (var file in files)
            {
                file.Storage = _storageService.StorageType;
                File addedFile = await _fileRepository.AddAsync(file);

                Image image = new() { FileId = file.Id, IsAi = uploadImageRequest.IsAi, IsPrivate = uploadImageRequest.IsPrivate };
                Image addedImage = await _imageRepository.AddAsync(image);
                response.Add(_mapper.Map<UploadImageResponse>(addedImage));
            }
            return response;
        }

        public async Task<IPaginate<GetListImageResponse>> GetListImageAsync(PageRequest pageRequest)
        {
            var images = await _imageRepository.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
            return _mapper.Map<Paginate<GetListImageResponse>>(images);
        }

        public async Task<PermanentDeleteImageResponse> PermanentDeleteImageAsync(PermanentDeleteImageRequest permanentDeleteImageRequest)
        {
            var selectedImage = await _imageRepository.GetAsync(t => t.Id == Guid.Parse(permanentDeleteImageRequest.Id));
            var deletedImage = await _imageRepository.DeleteAsync(selectedImage, permanent: true);
            return _mapper.Map<PermanentDeleteImageResponse>(deletedImage);
        }

        public async Task<SoftDeleteImageResponse> SoftDeleteImageAsync(SoftDeleteImageRequest softDeleteImageRequest)
        {
            var selectedImage = await _imageRepository.GetAsync(t => t.Id == Guid.Parse(softDeleteImageRequest.Id));
            var deletedImage = await _imageRepository.DeleteAsync(selectedImage, permanent: false);
            return _mapper.Map<SoftDeleteImageResponse>(deletedImage);
        }

        public async Task<UpdateImageResponse> UpdateImageAsync(UpdateImageRequest updateImageRequest)
        {
            var requestedImage = await _imageRepository.GetAsync(t => t.Id == Guid.Parse(updateImageRequest.Id));
            requestedImage = _mapper.Map(updateImageRequest, requestedImage);
            var updatedImage = await _imageRepository.UpdateAsync(requestedImage);
            return _mapper.Map<UpdateImageResponse>(updatedImage);
        }
    }
}
