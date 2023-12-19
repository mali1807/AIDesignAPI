using AutoMapper;
using Business.Abstract;
using Business.DTOs.Requests.Images;
using Business.DTOs.Responses.Images;
using Core.DataAccess.Paging;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public ImageManager(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public async Task<CreateImageResponse> CreateImageAsync(CreateImageRequest createImageRequest)
        {
            var image = _mapper.Map<Image>(createImageRequest);
            var createdImage = await _imageRepository.AddAsync(image);
            return _mapper.Map<CreateImageResponse>(createdImage);
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
