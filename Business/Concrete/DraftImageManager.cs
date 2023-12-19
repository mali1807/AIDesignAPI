using AutoMapper;
using Business.Abstract;
using Business.DTOs.Requests.DraftImages;
using Business.DTOs.Responses.DraftImages;
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
    public class DraftImageManager : IDraftImageService
    {
        private readonly IDraftImageRepository _draftImageRepository;
        private readonly IMapper _mapper;

        public DraftImageManager(IDraftImageRepository draftImageRepository, IMapper mapper)
        {
            _draftImageRepository = draftImageRepository;
            _mapper = mapper;
        }

        public async Task<CreateDraftImageResponse> CreateDraftImageAsync(CreateDraftImageRequest createDraftImageRequest)
        {
            var image = _mapper.Map<DraftImage>(createDraftImageRequest);
            var createdDraftImage = await _draftImageRepository.AddAsync(image);
            return _mapper.Map<CreateDraftImageResponse>(createdDraftImage);
        }

        public async Task<IPaginate<GetListDraftImageResponse>> GetListDraftImageAsync(PageRequest pageRequest)
        {
            var images = await _draftImageRepository.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
            return _mapper.Map<Paginate<GetListDraftImageResponse>>(images);
        }

        public async Task<PermanentDeleteDraftImageResponse> PermanentDeleteDraftImageAsync(PermanentDeleteDraftImageRequest permanentDeleteDraftImageRequest)
        {
            var selectedDraftImage = await _draftImageRepository.GetAsync(t => t.Id == Guid.Parse(permanentDeleteDraftImageRequest.Id));
            var deletedDraftImage = await _draftImageRepository.DeleteAsync(selectedDraftImage, permanent: true);
            return _mapper.Map<PermanentDeleteDraftImageResponse>(deletedDraftImage);
        }

        public async Task<SoftDeleteDraftImageResponse> SoftDeleteDraftImageAsync(SoftDeleteDraftImageRequest softDeleteDraftImageRequest)
        {
            var selectedDraftImage = await _draftImageRepository.GetAsync(t => t.Id == Guid.Parse(softDeleteDraftImageRequest.Id));
            var deletedDraftImage = await _draftImageRepository.DeleteAsync(selectedDraftImage, permanent: false);
            return _mapper.Map<SoftDeleteDraftImageResponse>(deletedDraftImage);
        }

        public async Task<UpdateDraftImageResponse> UpdateDraftImageAsync(UpdateDraftImageRequest updateDraftImageRequest)
        {
            var requestedDraftImage = await _draftImageRepository.GetAsync(t => t.Id == Guid.Parse(updateDraftImageRequest.Id));
            requestedDraftImage = _mapper.Map(updateDraftImageRequest, requestedDraftImage);
            var updatedDraftImage = await _draftImageRepository.UpdateAsync(requestedDraftImage);
            return _mapper.Map<UpdateDraftImageResponse>(updatedDraftImage);
        }
    }
}
